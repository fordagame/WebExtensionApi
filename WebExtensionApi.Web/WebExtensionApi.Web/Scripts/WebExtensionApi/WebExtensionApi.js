var WEAObjects = [];
WebExtensionApi.Views = {
    Initialize: -1,
    HTML: 1,
    CSS: 2,
    JavaScript: 3,
    Preview: 4,
    View: 5,
    Button: 6,
    View_HTML: 7,
    Preview_HTML: 8
}
WebExtensionApi.SaveType = {
    NoSave: 0,
    Database: 1,
    ExportFile: 2
}
function WebExtensionApi(options) {

    this.DataSourceLoadedCounter = 0;
    this.AllDataSources = 0;
    this.DataSources = {};
    if (options && options.dataSources) {
        this.AllDataSources = options.dataSources.length;
        for (var i in options.dataSources) {
            var dataSource = options.dataSources[i];
            var that = this;
            $.getJSON(dataSource.Url, function (data) {
                that.DataSources[dataSource.Name] = eval("(" + data + ")");
                that.DataSourceLoadedCounter++;
                if (that.AllDataSources == that.DataSourceLoadedCounter) {
                    that.AllDataSourcesLoaded();
                }
            });
        }
    }
    this.jQueryPath = options.jQueryPath;
    var scriptJquery = document.createElement("script");
    scriptJquery.type = "text/javascript";
    scriptJquery.src = this.jQueryPath;
    document.body.appendChild(scriptJquery);

    this.Options = options;
    this.ContainerID = this.Options.containerId;
    $("#" + this.ContainerID).html("Please wait untill all datasources are loaded!");
}
WebExtensionApi.prototype.AllDataSourcesLoaded = function () {
    this.LoadData = this.Options.LoadData;
    this.Width = this.Options.width;
    this.Height = this.Options.height;
    this.buildView();
    this.StateID = WebExtensionApi.Views.Initialize;
    this.ID = WEAObjects.length;
    WEAObjects[this.ID] = this;
    WEA = this;

    this.State = WebExtensionApi.Views.Initialize;
    this.JavaScriptText = "";
    this.HTMLText = "";
    this.CSSText = "";
    this.Container = "";

    this.SwitchView(WebExtensionApi.Views.View);
    var that = this;
    setTimeout(function(){ 
        that.LoadJquery(WebExtensionApi.Views.View_HTML);
        that.LoadJquery(WebExtensionApi.Views.Preview_HTML);
        setTimeout(function () {
            that.LoadSavedData()
        }, 100);}, 100);
}

WebExtensionApi.prototype.buildView = function () {
    that = this;
    $("#" + this.ContainerID).html("");
    $("#" + this.ContainerID).width(this.Width);
    $("#" + this.ContainerID).height(this.Height);
    if (this.Options.Info) {
        $("#" + this.ContainerID).append("<div id='" + this.ContainerID + "_info_container' >" + this.Options.Info + "</div>");
    }
    $("#" + this.ContainerID).append("<div id='" + this.ContainerID + "_button_container' ></div>");
    var buttonContainer = this.GetContainer(WebExtensionApi.Views.Button);
    buttonContainer.append("<input type='button' id='" + this.ContainerID + "_HTMLButton' value='HTML' />");
    $("#" + this.ContainerID + "_HTMLButton").click(function () {
        that.HTML();
    })
    buttonContainer.append("<input type='button' id='" + this.ContainerID + "_CSSButton' value='CSS' />");
    $("#" + this.ContainerID + "_CSSButton").click(function () {
        that.CSS();
    })
    buttonContainer.append("<input type='button' id='" + this.ContainerID + "_JavaScriptButton' value='JavaScript' />");
    $("#" + this.ContainerID + "_JavaScriptButton").click(function () {
        that.JavaScript();
    })
    buttonContainer.append("<input type='button' id='" + this.ContainerID + "_PreviewButton' value='Preview' />");
    $("#" + this.ContainerID + "_PreviewButton").click(function () {
        that.Preview();
    })
    buttonContainer.append("<input type='button' id='" + this.ContainerID + "_ViewButton' value='View' />");
    $("#" + this.ContainerID + "_ViewButton").click(function () {
        that.View();
    })
    buttonContainer.append("<input type='button' id='" + this.ContainerID + "_SaveButton' value='Save' />");
    $("#" + this.ContainerID + "_SaveButton").click(function () {
        that.Save();
    })

    //HTML
    $("#" + this.ContainerID).append("<div id='" + this.ContainerID + "_HTMLContainer' style='display: none;'  class='wea_container'></div>");
    this.GetContainer(WebExtensionApi.Views.HTML).append("<textarea class='wea_ide_textarea' placeholder='HTML Code' />");
    //CSS
    $("#" + this.ContainerID).append("<div id='" + this.ContainerID + "_CSSContainer' style='display: none;'  class='wea_container'></div>");
    this.GetContainer(WebExtensionApi.Views.CSS).append("<textarea class='wea_ide_textarea' placeholder='CSS Code' />");
    //JavaScript
    $("#" + this.ContainerID).append("<div id='" + this.ContainerID + "_JavaScriptContainer' style='display: none;'  class='wea_container'></div>");
    this.GetContainer(WebExtensionApi.Views.JavaScript).append("<textarea class='wea_ide_textarea' placeholder='JS Code' />");
    //Preview
    $("#" + this.ContainerID).append("<div id='" + this.ContainerID + "_PreviewContainer' style='display: none;'  class='wea_container'></div>");
    this.GetContainer(WebExtensionApi.Views.Preview).append("<iframe id='" + this.ContainerID + "_preview_extension_container' class='extension_container_frame'></iframe>");
    
    //View
    $("#" + this.ContainerID).append("<div id='" + this.ContainerID + "_ViewContainer' style='display: none;'  class='wea_container'></div>");
    this.GetContainer(WebExtensionApi.Views.View).append("<input type='button' id='" + this.ContainerID + "_regenerate_html' value='Regenerate content' /><br />");
    this.GetContainer(WebExtensionApi.Views.View).append("<iframe id='" + this.ContainerID + "_extension_container' class='extension_container_frame'></iframe>");
    
    $("#" + this.ContainerID + "_regenerate_html").click(function () {
        that.GenerateExtension(WebExtensionApi.Views.View_HTML);
    })


}

WebExtensionApi.prototype.GetContainer = function (viewId) {
    var container = null;
    switch (viewId) {
        case WebExtensionApi.Views.Initialize:
            break;
        case WebExtensionApi.Views.JavaScript:
            container = $("#" + this.ContainerID + "_JavaScriptContainer");
            break;
        case WebExtensionApi.Views.CSS:
            container = $("#" + this.ContainerID + "_CSSContainer");
            break;
        case WebExtensionApi.Views.HTML:
            container = $("#" + this.ContainerID + "_HTMLContainer");
            break;
        case WebExtensionApi.Views.View:
            container = $("#" + this.ContainerID + "_ViewContainer");
            break;
        case WebExtensionApi.Views.Preview:
            container = $("#" + this.ContainerID + "_PreviewContainer");
            break;
        case WebExtensionApi.Views.Button:
            container = $("#" + this.ContainerID + "_button_container");
            break;
        case WebExtensionApi.Views.View_HTML:
            container = $("#" + this.ContainerID + "_extension_container");
            break;
        case WebExtensionApi.Views.Preview_HTML:
            container = $("#" + this.ContainerID + "_preview_extension_container");
            break;
    }
    return container;
}

WebExtensionApi.prototype.SwitchView = function (viewId) {
    var oldContainer = this.GetContainer(this.StateID);
    if (oldContainer != null) {
        oldContainer.hide();
        switch (this.StateID) {
            case WebExtensionApi.Views.Initialize:
                break;
            case WebExtensionApi.Views.JavaScript:
                this.JavaScriptText = $(oldContainer.find("textarea")).val();
                break;
            case WebExtensionApi.Views.CSS:
                this.CSSText = $(oldContainer.find("textarea")).val();
                break;
            case WebExtensionApi.Views.HTML:
                this.HTMLText = $(oldContainer.find("textarea")).val();
                break;
            case WebExtensionApi.Views.View:
                break;
            case WebExtensionApi.Views.Preview:
                break;
        }
    }
    var newContainer = this.GetContainer(viewId);
    if (newContainer != null) {
        newContainer.show();
        switch (viewId) {
            case WebExtensionApi.Views.Initialize:
                break;
            case WebExtensionApi.Views.JavaScript:
                newContainer.find("textarea").focus();
                break;
            case WebExtensionApi.Views.CSS:
                newContainer.find("textarea").focus();
                break;
            case WebExtensionApi.Views.HTML:
                newContainer.find("textarea").focus();
                break;
            case WebExtensionApi.Views.View:
                break;
            case WebExtensionApi.Views.Preview:
                this.GenerateExtension(WebExtensionApi.Views.Preview_HTML);
                break;
        }
    }
    this.StateID = viewId;
}

WebExtensionApi.prototype.JavaScript = function () {
    this.SwitchView(WebExtensionApi.Views.JavaScript);
}

WebExtensionApi.prototype.HTML = function () {
    this.SwitchView(WebExtensionApi.Views.HTML);
}

WebExtensionApi.prototype.CSS = function () {
    this.SwitchView(WebExtensionApi.Views.CSS);
}

WebExtensionApi.prototype.View = function () {
    this.SwitchView(WebExtensionApi.Views.View);
}

WebExtensionApi.prototype.Preview = function () {
    this.SwitchView(WebExtensionApi.Views.Preview);
}

WebExtensionApi.prototype.Serialize = function () {
    var SerializedObject = {
        HTML: this.HTMLText,
        CSS: this.CSSText,
        JavaScript: this.JavaScriptText
    };
    return JSON.stringify(SerializedObject);
}

WebExtensionApi.prototype.LoadJquery = function (viewId) {

    var container = this.GetContainer(viewId);
    var doc = container[0].contentWindow.document;
    //loading jquery
    var scriptJquery = doc.createElement("script");
    scriptJquery.type = "text/javascript";
    scriptJquery.src = this.jQueryPath;
    doc.body.appendChild(scriptJquery);
}


WebExtensionApi.prototype.GenerateExtension = function (viewId) {
    var container = this.GetContainer(viewId);
    var doc = container[0].contentWindow.document;
    var body = $('body', doc);
    body.html(this.HTMLText);
    body.append("<style>" + this.CSSText + "</style>");

    var script = doc.createElement("script");
    script.type = "text/javascript";
    script.text = "DataSources = parent.webExtensionApi.DataSources;";
    script.text += this.JavaScriptText;
    doc.body.appendChild(script);
}

WebExtensionApi.prototype.Save = function () {
    if (!this.Options.SaveType || this.Options.SaveType == WebExtensionApi.SaveType.NoSave) {
        alert("Developer doesn't allow save option");
    }
    else if (this.Options.SaveType == WebExtensionApi.SaveType.Database && this.Options.SaveURL) {
        this.JavaScriptText = $(this.GetContainer(WebExtensionApi.Views.JavaScript).find("textarea")).val();
        this.CSSText = $(this.GetContainer(WebExtensionApi.Views.CSS).find("textarea")).val();
        this.HTMLText = $(this.GetContainer(WebExtensionApi.Views.HTML).find("textarea")).val();
        $.post(this.Options.SaveURL, { "serializedBlog": this.Serialize() }, function (result) {
            alert("Save successful");
        })
    }
}

WebExtensionApi.prototype.LoadSavedData = function () {
    if (this.LoadData) {
        if (this.LoadData.HTML) {
            var container = this.GetContainer(WebExtensionApi.Views.HTML)
            container.find("textarea").val(this.LoadData.HTML);
            this.HTMLText = this.LoadData.HTML;
        }
        if (this.LoadData.CSS) {
            var container = this.GetContainer(WebExtensionApi.Views.CSS)
            container.find("textarea").val(this.LoadData.CSS);
            this.CSSText = this.LoadData.CSS;
        }
        if (this.LoadData.JavaScript) {
            var container = this.GetContainer(WebExtensionApi.Views.JavaScript)
            container.find("textarea").val(this.LoadData.JavaScript);
            this.JavaScriptText = this.LoadData.JavaScript;
        }
        this.GenerateExtension(WebExtensionApi.Views.View_HTML);
    }
}