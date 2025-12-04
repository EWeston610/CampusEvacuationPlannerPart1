using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        WeightedList list = new WeightedList();

        BuildingData.LoadGraph(list);

        //list.DisplayAll();
        //Console.WriteLine();

        //list.DisplaySummary();
        //Console.WriteLine();

        list.FindAndDisplayQuickestExits();
    }
}
