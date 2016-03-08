using System;
using System.Collections.Generic;

using System.Text;


namespace Map2CivilizationCtrl.Listener
{
    public interface IUiListenerProgress : IUiListener
    {
        void SetProgressPercent(int percent);
        void ProgressStarted();
        void ProgressFinished();
        
    }
}
