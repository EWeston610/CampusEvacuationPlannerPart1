static class BuildingData
{
    public static void LoadGraph(WeightedList list)
    {
        // FIRST FLOOR HALLWAY
        list.AddEdge("A", "B", 4);
        list.AddEdge("B", "C", 4);
        list.AddEdge("C", "D", 3);
        list.AddEdge("D", "E", 3);
        list.AddEdge("E", "F", 6);
        list.AddEdge("F", "G", 2);
        list.AddEdge("G", "H", 4);
        list.AddEdge("H", "I", 3);

        // FIRST FLOOR EXITS
        list.AddExit("A", "Exit1", 0);
        list.AddExit("C", "Exit2", 1);
        list.AddExit("D", "Exit3", 2);
        list.AddExit("E", "Exit4", 2);
        list.AddExit("I", "Exit5", 0);

        // FIRST FLOOR ROOMS
        list.AddSpecialNode("C", "122", 4);
        list.AddSpecialNode("C", "124", 4);
        list.AddSpecialNode("B", "123", 4);

        list.AddSpecialNode("G", "154", 2);
        list.AddSpecialNode("G", "143", 2);
        list.AddSpecialNode("H", "142", 3);
        list.AddSpecialNode("H", "151", 4);

        // STAIRS (to second floor)
        list.AddEdge("A", "AA", 8);
        list.AddEdge("E", "DD", 6);
        list.AddEdge("I", "GG", 8);

        // SECOND FLOOR HALLWAY
        list.AddEdge("AA", "BB", 6);
        list.AddEdge("BB", "CC", 2);
        list.AddEdge("CC", "DD", 6);
        list.AddEdge("DD", "EE", 8);
        list.AddEdge("EE", "FF", 3);
        list.AddEdge("FF", "GG", 2);

        // SECOND FLOOR ROOMS
        list.AddSpecialNode("BB", "223", 6);
        list.AddSpecialNode("CC", "225", 2);
        list.AddSpecialNode("EE", "254", 8);
        list.AddSpecialNode("EE", "243", 3);
        list.AddSpecialNode("FF", "251", 2);

        // STAIRS (to third floor)
        list.AddEdge("AA", "AAA", 8);
        list.AddEdge("DD", "CCC", 6);
        list.AddEdge("GG", "GGG", 8);

        // THIRD FLOOR HALLWAY
        list.AddEdge("AAA", "BBB", 6);
        list.AddEdge("BBB", "CCC", 8);
        list.AddEdge("CCC", "DDD", 4);
        list.AddEdge("DDD", "EEE", 4);
        list.AddEdge("EEE", "FFF", 2);
        list.AddEdge("FFF", "GGG", 3);

        // THIRD FLOOR ROOMS
        list.AddSpecialNode("BBB", "323", 6);
        list.AddSpecialNode("BBB", "324", 8);

        list.AddSpecialNode("DDD", "354", 4);

        list.AddSpecialNode("EEE", "353", 4);
        list.AddSpecialNode("EEE", "343", 4);

        list.AddSpecialNode("FFF", "342", 2);
        list.AddSpecialNode("FFF", "341", 3);

        list.AddSpecialNode("GGG", "351", 3);
    }
}
