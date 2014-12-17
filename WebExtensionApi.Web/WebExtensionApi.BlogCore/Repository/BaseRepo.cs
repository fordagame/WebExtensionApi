using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExtensionApi.BlogCore.DAL;

namespace WebExtensionApi.BlogCore.Repository
{
    public abstract class BaseRepo<TEntity> where TEntity : class
    {
        #region Constructor

        [InjectionConstructor]
        public BaseRepo(BlogEntities context)
        {
            this.Context = context;
        }

        #endregion

        #region Private Variables

        private DbSet<TEntity> dbSet;

        private DbSet<TEntity> DbSet
        {
            get
            {
                if (this.dbSet == null)
                {
                    this.dbSet = this.Context.Set<TEntity>();
                }

                return this.dbSet;
            }
        }

        #endregion

        #region Protected Properties

        protected BlogEntities Context { get; set; }

        #endregion

        #region Public Methods

        public virtual void Add(TEntity entity)
        {
            this.DbSet.Add(entity);
        }

        public virtual void Add(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                this.DbSet.Add(entity);
            }
        }

        public virtual void Attach(TEntity entity)
        {
            this.DbSet.Attach(entity);
        }

        public virtual void Attach(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                this.DbSet.Attach(entity);
            }
        }

        public virtual long Create(TEntity entity)
        {
            this.DbSet.Add(entity);

            return this.SaveChanges();
        }

        public virtual void Create(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                this.DbSet.Add(entity);
            }

            this.SaveChanges();
        }

        public virtual long Delete(TEntity entity)
        {
            this.DbSet.Remove(entity);

            return this.SaveChanges();
        }

        public virtual long Delete(IEnumerable<TEntity> entities)
        {
            while (entities.Count() > 0)
            {
                var entity = entities.FirstOrDefault();
                this.DbSet.Remove(entity);
            }
            return this.SaveChanges();
        }

        public virtual void DeleteWithoutSave(TEntity entity)
        {
            this.DbSet.Remove(entity);
        }

        public virtual void DeleteWithoutSave(IEnumerable<TEntity> entities)
        {
            while (entities.Count() > 0)
            {
                var entity = entities.FirstOrDefault();
                this.DbSet.Remove(entity);
            }

        }

        public virtual int SaveChanges()
        {
            try
            {
                return this.Context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                string exception = "";
                foreach (var eve in e.EntityValidationErrors)
                {
                    exception = string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        exception += string.Format("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw new Exception(exception);
            }
        }

        #endregion

    }
}
