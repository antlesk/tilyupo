using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2._1._24
{
    class AMPProgect
    {
        const decimal CableCost = 1.5M;
        const decimal PowerSocketCost = 1M;
        const decimal ConnectorCost = 1M;
        const decimal CupboardCost = 110M;

        const decimal CupboardInstallationCost = 33M;
        const decimal ChannelPunchingCost = 20M;

        const float PlanningCoefficient = 0.2F;

        public int ConnectionCount { get; set; }
        public int FloorsCount { get; set; }
        public int WallWidth { get; set; }
        public int FloorHeight { get; set; }
        public int Distanse { get; set; }

        public int PowerSocketsCount { get { return ConnectionCount; } }
        public int ConnectorsCount { get { return 2 * ConnectionCount; } }
        public int CupboardsCount { get { return FloorsCount; } }

        public AMPProgect()
        { 
        }

        public int CalcTotalLength()
        {
            return ConnectionCount * Distanse + (FloorHeight + WallWidth) * (FloorsCount - 1);
        }

        public decimal CalcEquipmentCost() 
        {
            return CalcTotalLength() * CableCost + PowerSocketsCount * PowerSocketCost +
                ConnectionCount * ConnectorCost + CupboardsCount * CupboardCost;
        }

        public decimal CalcWorkCost()
        {
            return CupboardsCount * CupboardInstallationCost + ChannelPunchingCost * (FloorsCount - 1);
        }

        public decimal CalcPlanningCost()
        {
            return (CalcEquipmentCost() + CalcWorkCost()) * (decimal)PlanningCoefficient;

        }

        public decimal CalcTotalCost()
        {
            return CalcWorkCost() + CalcPlanningCost() + CalcEquipmentCost();
        }

        public static string Info { get { return "Компания (с) AMP Тел: +375259184040"; } }
    }
}
