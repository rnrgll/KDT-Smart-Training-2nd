using System.Drawing;

namespace Practice0313;

public class Diamond2
{
    static void Main(string[] args)
    {
        //0,0에서 출발하라는 법은 없음 중간점을 0,0으로 놓고 해보자
        int size = 5;
        for(int y =- size; y<=size; y++)
        {
            for (int x = -3; x <= 3; x++)
            {
                int xPos = x;
                if (xPos < 0)
                {
                    xPos = -xPos;
                }

                int yPos = y;
                if (yPos < 0)
                {
                    yPos = -yPos;
                }



            }
        }
    }
    

}