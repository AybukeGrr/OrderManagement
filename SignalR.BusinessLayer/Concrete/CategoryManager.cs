using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccesssLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    internal class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            this.categoryDal = categoryDal;
        }

        public void TAdd(Category entity)
        {
            _categoryDal.Add(entity);
        }

        public void TDelete(Category entity)
        {
            _categoryDal.Delete(entity);
        }

        public Category TGetById(int id)
        {
            return _categoryDal.GetById(id);    
        }

        public List<Category> TGetListAll()
        {
            return _categoryDal.GetListAll();
        }

        public void TUpdate(Category entity)
        {
            _categoryDal.Update(entity);
        }
    }
}
