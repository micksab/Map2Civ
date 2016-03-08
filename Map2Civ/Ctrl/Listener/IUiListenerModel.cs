using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Map2CivilizationCtrl.Listener
{
    public interface IUiListenerModel : IUiListener
    {
        void ModelChanged();
        void UpdateCurrentModelFile(string fileName);
    }
}
