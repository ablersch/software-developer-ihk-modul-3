using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;

namespace Medienauswahl_Aufgabe_GUI
{

    static class Data
    {
        private static Dictionary<int,Object> medienDic = new Dictionary<int, Object>();
       
        /// <summary>
        /// Daten speichern
        /// </summary>
        /// <param name="key">ID des Elements</param>
        /// <param name="data">Das zu speichernde Datenobjekt</param>
        internal static void AddData(int key, Object data)
        {
            medienDic.Add(key, data);
        }

        /// <summary>
        /// Prüfen ob die ID/Key eindeutig ist
        /// </summary>
        /// <param name="key">Zu prüfende ID</param>
        /// <returns>true = id erlaubt  ;  false = id nicht erlaubt</returns>
        internal static bool IsKeyEindeutig(int key)
        {
            if (medienDic.ContainsKey(key))
            {
                MessageBox.Show("Signatur existiert bereits");
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Gibt alle Elemente zurück
        /// </summary>
        /// <returns>Eine ArrayList das alle Elemente beinhaltet</returns>
        internal static ArrayList GetAllElements()
        {
            ArrayList arrayList = new ArrayList();

            foreach (KeyValuePair<int, Object> medien in medienDic)
            {
                arrayList.Add(medien.Value);
            }
            return arrayList;
        }

        /// <summary>
        /// Holt ein Element
        /// </summary>
        /// <param name="key">ID/Key des Elements</param>
        /// <returns>Wurde das Element gefunden wird das Object zurückgegebene, ansonsten null</returns>
        internal static Object GetElement(int key)
        {
            if (medienDic.ContainsKey(key))
            {
                Object tempObject = medienDic[key];
                return tempObject;
            }
            else
            {
                MessageBox.Show("Signatur nicht gefunden!");
                return null;
            }
        }

        /// <summary>
        /// Löscht ein Elment
        /// </summary>
        /// <param name="key">ID/Key des Elements</param>
        internal static void DeleteElement(int key)
        {
            if (medienDic.ContainsKey(key))
            {
                medienDic.Remove(key);
                MessageBox.Show("Medium mit der Signatur: " + key + " erfolgreich gelöscht.");
            }
        }    
    }
}
