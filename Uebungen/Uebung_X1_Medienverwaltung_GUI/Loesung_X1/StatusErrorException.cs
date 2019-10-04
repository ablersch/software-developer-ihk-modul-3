using System;
using Logger;

namespace Medienauswahl_Aufgabe_GUI {

    class StatusErrorException : Exception {

        //private int sig = 0;

        //public StatusErrorException(int sig) {
        //    this.sig = sig;
        //}
        
        public StatusErrorException() : base() {
            
        }

        public StatusErrorException(string meldung)
            : base(meldung) {
            WriteToLog();
        }

        public StatusErrorException(string meldung, Exception exception)
            : base(meldung, exception) {
            WriteToLog();
        }

        public override string Message {
            get {
                return "Fehler beim Leihen/Rueckgeben von Signatur: " + base.Message;
            }
        }

        private void WriteToLog() {
            LoggerUtil.WriteLogToFile(Message, LoggerUtil.LogTyp.WARNING);
        }
    }
}
