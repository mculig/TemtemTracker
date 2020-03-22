using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemtemTracker.Data;
using Newtonsoft.Json;
using System.Collections.Concurrent;

namespace TemtemTracker.Controllers
{
    public class TemtemTableController
    {

        //Locations of things
        static readonly string tableFile = @"savedData\table.json";

        //The Luma calculator
        LumaChanceCalculator lumaCalculator;

        //The various UI elements we need to control
        TemtemTrackerUI trackerUI;

        //The data table we load from JSON or set up
        TemtemDataTable dataTable;

        //A hash map between UI rows and data elements used when inserting or deleting elements
        Dictionary<TemtemDataRow, TemtemTableRowUI> UIRows;

        public TemtemTableController(TemtemTrackerUI trackerUI, LumaChanceCalculator lumaCalculator, SettingsController settingsController)
        {
            this.trackerUI = trackerUI;
            this.lumaCalculator = lumaCalculator;

            settingsController.SetTableController(this);

            UIRows = new Dictionary<TemtemDataRow, TemtemTableRowUI>();

            //Deserialize user data OR create missing objects
            if (File.Exists(tableFile))
            {
                string json = File.ReadAllText(tableFile);
                dataTable = JsonConvert.DeserializeObject<TemtemDataTable>(json);
            }
            else
            {
                dataTable = new TemtemDataTable();
                dataTable.rows = new List<TemtemDataRow>();
                //Total row
                dataTable.total = new TemtemDataRow();
                dataTable.total.name = "Total";
                dataTable.total.encountered = 0;
                dataTable.total.encounteredPercent = 0.0;
                dataTable.total.lumaChance = 0.0;
                dataTable.total.timeToLuma = 0;
                //Timer data
                dataTable.timer = new TimerData();
                dataTable.timer.durationTime = 0;
                dataTable.timer.temtemCount = 0;
            }
            //Set up the UI
            foreach(TemtemDataRow row in dataTable.rows){
                TemtemTableRowUI rowUI = new TemtemTableRowUI(row, this);
                UIRows[row] = rowUI;
                trackerUI.AddRowToTable(rowUI);
            }
            //Set up the total
            trackerUI.SetTotal(dataTable.total);
            //Update time and temtem/h
            trackerUI.UpdateTime(dataTable.timer.durationTime);
            updateTemtemH();

            //Set this as the table controller in the UI
            trackerUI.SetTableController(this);
        }

        public void RemoveRow(TemtemDataRow row)
        {
            //Remove UI element from UI
            trackerUI.RemoveRowFromTable(UIRows[row]);
            //Remove UI <-> data binding from hash map
            UIRows.Remove(row);
            //Remove row info from total
            dataTable.total.encountered -= row.encountered;
            dataTable.total.lumaChance = lumaCalculator.CalculateChance(dataTable.total.encountered, "");
            dataTable.total.timeToLuma = lumaCalculator.GetTimeToLuma(dataTable.total.encountered, dataTable.timer.durationTime, "");
            trackerUI.UpdateTotal();
            //Remove data from dataTable
            dataTable.rows.Remove(row);
            //Recalculate encountered %
            foreach (KeyValuePair<TemtemDataRow, TemtemTableRowUI> entry in UIRows)
            {
                entry.Key.encounteredPercent = entry.Key.encountered / (double)dataTable.total.encountered;
                entry.Value.UpdateRow();
            }
        }

        public void AddTemtem(string temtemName)
        {
            TemtemDataRow targetRow = null;
            foreach(TemtemDataRow row in dataTable.rows)
            {
                if (string.Compare(row.name,temtemName)==0)
                {
                    targetRow = row;
                    break;
                }
            }
            if(targetRow == null)
            {
                //We didn't find the row, set up a new one
                targetRow = new TemtemDataRow();
                targetRow.name = temtemName;
                targetRow.encountered = 0;
                dataTable.rows.Add(targetRow);
                UIRows[targetRow] = new TemtemTableRowUI(targetRow, this);
                trackerUI.AddRowToTable(UIRows[targetRow]);
            }
            //Calculate stuff
            dataTable.total.encountered++;
            dataTable.total.lumaChance = lumaCalculator.CalculateChance(dataTable.total.encountered, dataTable.total.name);
            dataTable.total.timeToLuma = lumaCalculator.GetTimeToLuma(dataTable.total.encountered, dataTable.timer.durationTime, dataTable.total.name);
            targetRow.encountered++;
            targetRow.lumaChance = lumaCalculator.CalculateChance(targetRow.encountered, targetRow.name);
            targetRow.timeToLuma = lumaCalculator.GetTimeToLuma(targetRow.encountered, dataTable.timer.durationTime, targetRow.name);
            targetRow.encounteredPercent = targetRow.encountered / (double)dataTable.total.encountered;
            UIRows[targetRow].UpdateRow();
            trackerUI.UpdateTotal();
            //Recalculate encountered %
            foreach(KeyValuePair<TemtemDataRow, TemtemTableRowUI> entry in UIRows)
            {
                entry.Key.encounteredPercent = entry.Key.encountered / (double) dataTable.total.encountered;
                entry.Value.UpdateRow();
            }
            updateTemtemH();
        }

        public void ResetTable()
        {
            dataTable.rows.Clear();
            trackerUI.RemoveAllTableRows();
            UIRows.Clear();
            dataTable.timer.durationTime = 0;
            dataTable.timer.temtemCount = 0;
            dataTable.total.encountered = 0;
            dataTable.total.encounteredPercent = 1;
            dataTable.total.lumaChance = 0;
            dataTable.total.timeToLuma = 0;
            trackerUI.UpdateTotal();
            trackerUI.UpdateTemtemH(0);
            trackerUI.UpdateTime(0);
        }

        public void UpdateLumaTimes()
        {
            foreach(KeyValuePair<TemtemDataRow, TemtemTableRowUI> entry in UIRows)
            {
                entry.Key.timeToLuma = lumaCalculator.GetTimeToLuma(entry.Key.encountered, dataTable.timer.durationTime, entry.Key.name);
                entry.Value.UpdateRow();
            }
            dataTable.total.timeToLuma = lumaCalculator.GetTimeToLuma(dataTable.total.encountered, dataTable.timer.durationTime, dataTable.total.name);
            trackerUI.UpdateTotal();
        }

        public void IncrementTimer()
        {
            dataTable.timer.durationTime += 1000;
            trackerUI.UpdateTime(dataTable.timer.durationTime);
        }

        private void updateTemtemH()
        {
            dataTable.timer.temtemCount = dataTable.total.encountered;
            trackerUI.UpdateTemtemH(dataTable.timer.temtemCount/((double) dataTable.timer.durationTime/ 3600000));
        }

        public void SaveTable()
        {
            String jsonTable = JsonConvert.SerializeObject(dataTable);
            File.WriteAllText(tableFile, jsonTable);
        }


    }
}
