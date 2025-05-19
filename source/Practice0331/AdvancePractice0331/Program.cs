namespace AdvancePractice0331;

class Program
{
    static void Main(string[] args)
    {
        StationLine subwayLine = new StationLine(20);
        Init(ref subwayLine);
        
        string from, to; //출발지, 목적지
        
        subwayLine.PrintStastionLine();
        
        //입력
        Console.Write("출발역 이름 입력 : ");
        from = Console.ReadLine();
        
        Console.Write("도착역 이름 입력 : ");
        to = Console.ReadLine();

        Console.WriteLine();
        
        subwayLine.FindShortestPath(from, to);

    }

    static void Init(ref StationLine subwayLine)
    {
        subwayLine = new StationLine(20);
        
        //1호선
        subwayLine.AddNode("서울역");
        subwayLine.AddNode("시청역");
        subwayLine.AddNode("종각역");
        subwayLine.AddNode("종로3가역");
        subwayLine.AddNode("동대문역사문화공원역");
        
        //2호선
        subwayLine.AddNode("을지로입구역");
        subwayLine.AddNode("을지로3가역");
        subwayLine.AddNode("을지로4가역");
        subwayLine.AddNode("동대문역사문화공원역");
        subwayLine.AddNode("왕십리역");

        //3호선
        subwayLine.AddNode("고속터미널역");
        subwayLine.AddNode("교대역");
        subwayLine.AddNode("을지로3가역");
        subwayLine.AddNode("안국역");
        subwayLine.AddNode("경복궁역");
        
        // 노선 연결
        // 1호선
        subwayLine.AddEdgeCycle("서울역", "시청역", 3);
        subwayLine.AddEdgeCycle("시청역", "종각역", 2);
        subwayLine.AddEdgeCycle("종각역", "종로3가역", 2);
        subwayLine.AddEdgeCycle("종로3가역", "동대문역사문화공원역", 3);

        // 2호선
        subwayLine.AddEdgeCycle("을지로입구역", "을지로3가역", 2);
        subwayLine.AddEdgeCycle("을지로3가역", "을지로4가역", 2);
        subwayLine.AddEdgeCycle("을지로4가역", "동대문역사문화공원역", 3);
        subwayLine.AddEdgeCycle("동대문역사문화공원역", "왕십리역", 4);

        // 3호선
        subwayLine.AddEdgeCycle("고속터미널역", "교대역", 3);
        subwayLine.AddEdgeCycle("교대역", "을지로3가역", 2);
        subwayLine.AddEdgeCycle("을지로3가역", "안국역", 2);
        subwayLine.AddEdgeCycle("안국역", "경복궁역", 3);
        
    }
}