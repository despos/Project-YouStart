///////////////////////////////////////////////////////////////////
//
// STARTER-KIT : demo app 
// Copyright (c) D.E. 2017
//
// Author: Dino Esposito
//

using Expoware.YouStart.Common.Exceptions;
using Expoware.YouStart.Resources;

namespace Expoware.YouStart.Models
{
    public class ErrorViewModel : ViewModelBase
    {
        public ErrorViewModel(string message, bool isAppSpecific = false)
        {
            ErrorOccurred = new YouStartAppException(message)
            {
                Title = Strings_Errors.Msg_SomethingWentWrong,
                IsAppSpecificError = isAppSpecific
            };
        }

        public YouStartAppException ErrorOccurred { get; private set; }
    }
}