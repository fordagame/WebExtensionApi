function WebExtensionApi(options) {
    console.info(options);
    this.DataSources = {};
    if (options && options.dataSources) {
        for (var i in options.dataSources) {
            var dataSource = options.dataSources[i];
            var that = this;
            $.getJSON(dataSource.Url, function (data) {
                that.DataSources[dataSource.Name] = eval("(" + data + ")");
            });
        }
    }
    this.ContainerID = options.containerId;
    $("#" + options.containerId).width(options.width);
    $("#" + options.containerId).height(options.height);
   
}
