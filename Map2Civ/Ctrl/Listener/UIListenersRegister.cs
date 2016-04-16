/************************************************************************************/
//
//      This file is part of Map2Civilization.
//      Map2Civilization is free software: you can redistribute it and/or modify
//      it under the terms of the GNU General Public License as published by
//      the Free Software Foundation, either version 3 of the License, or
//      (at your option) any later version.
//
//      Map2Civilization is distributed in the hope that it will be useful,
//      but WITHOUT ANY WARRANTY; without even the implied warranty of
//      MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//      GNU General Public License for more details.
//
//      You should have received a copy of the GNU General Public License
//      along with Map2Civilization.  If not, see http://www.gnu.org/licenses/.
//
/************************************************************************************/


using System;
using System.Collections.ObjectModel;

namespace Map2CivilizationCtrl.Listener
{
    public class UIListenersRegister<T> where T : IUiListener
    {
        private readonly Collection<T> _internalList = new Collection<T>();

        public Collection<T> ListenersList
        {
            get
            {
                return _internalList;
            }
        }

        public void RegisterObserver(T implementer)
        {
            _internalList.Add(implementer);
        }

        public void DeregisterObserver(T implementer)
        {
            _internalList.Remove(implementer);
        }

        public Boolean Contains(T implementer)
        {
            return _internalList.Contains(implementer);
        }
    }
}