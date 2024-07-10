using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pracownicy.Presenter
{
    class MainPresenter
    {
        private View.Form1 _view;
        private Model.Model _model;

        public MainPresenter(View.Form1 view, Model.Model model)
        {
            _view = view;
            _model = model;

            _view.AddRow += _view_AddRow;
            _view.SaveData += _view_SaveData;
            _view.LoadData += _view_LoadData;
            _view.LoadDataClicked += _view_LoadDataClicked;
        }

        private void _view_AddRow()
        {
            _model.ListBoxTmp = new Model.ListBoxText(_view);
            _model.ListBoxTmp.AddRow();
            
        }

        private void _view_SaveData()
        {
            _model.ListBoxTmp = new Model.ListBoxText(_view);
            _model.ListBoxTmp.SaveData();
        }

        private void _view_LoadData()
        {
            _model.ListBoxTmp = new Model.ListBoxText(_view);
            _model.ListBoxTmp.LoadData();
        }
        private void _view_LoadDataClicked(string selectedItem)
        {
            _model.ListBoxTmp = new Model.ListBoxText(_view);
            _model.ListBoxTmp.LoadDataClicked(selectedItem);
        }
    }
}
