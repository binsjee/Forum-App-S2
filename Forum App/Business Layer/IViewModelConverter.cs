using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Layer
{
    public interface IViewModelConverter<TModel, TViewModel>
    {
        TViewModel ModelToViewModel(TModel model);
        TModel ViewModelToModel(TViewModel viewmodel);

        List<TViewModel> ModelsToViewModels(List<TModel> models);
        List<TModel> ViewModelsToModels(List<TViewModel> viewmodels);
    }
}
