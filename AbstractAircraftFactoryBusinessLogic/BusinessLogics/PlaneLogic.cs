using AbstractAircraftFactoryBusinessLogic.BindingModels;
using AbstractAircraftFactoryBusinessLogic.Interfaces;
using AbstractAircraftFactoryBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace AbstractAircraftFactoryBusinessLogic.BusinessLogics
{
    public class PlaneLogic
    {
        private readonly IPlaneStorage _planeStorage;

        public PlaneLogic(IPlaneStorage planeStorage)
        {
            _planeStorage = planeStorage;
        }

        public List<PlaneViewModel> Read(PlaneBindingModel model)
        {
            if (model == null)
            {
                return _planeStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<PlaneViewModel> { _planeStorage.GetElement(model) };
            }
            return _planeStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(PlaneBindingModel model)
        {
            var plane = _planeStorage.GetElement(new PlaneBindingModel
            {
                Id = model.Id,
                PlaneName = model.PlaneName,
                Price = model.Price,
                PlaneComponents = model.PlaneComponents,
            });
            if (plane != null && plane.Id != model.Id)
            {
                throw new Exception("Уже есть самолет с таким названием");
            }
            if (model.Id.HasValue)
            {
                _planeStorage.Update(model);
            }
            else
            {
                _planeStorage.Insert(model);
            }
        }

        public void Delete(PlaneBindingModel model)
        {
            var plane = _planeStorage.GetElement(new PlaneBindingModel {
                Id = model.Id,
                PlaneName = model.PlaneName,
                Price = model.Price,
                PlaneComponents = model.PlaneComponents,
            });
            if (plane == null)
            {
                throw new Exception("Самолет не найден");
            }
            _planeStorage.Delete(model);
        }
    }
}
