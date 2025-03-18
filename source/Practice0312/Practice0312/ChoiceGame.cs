namespace Practice0312;

class ChoiceGame
{
    static void Main(string[] args)
    {
        //점수
        int score = 0;
        
        //점수 컷
        int greatValue = 80;
        int goodValue = 60;
        int sosoValue = 30;

        //질문
        int totalQCnt = 5;
        int currentQIdx = 0;
        
        #region Question

        string q1 = "Q1. 공포 영화를 좋아하시나요?\n1. 공포 영화 마니아!\t2. 싫어하진 않아요\t3. 공포 영화 극혐;";
        string q2= "Q2. 새로운 음식에 도전하는 스타일?\n1. 뭐든 도전! 신메뉴 환영!\t2. 익숙한 맛 위주로\t3. 모르는 건 절대 안 먹음";
        string q3= "Q3. 여름에 뜨거운 아메리카노 마시가 vs 겨울에 아이스 아메리카노 마시기\n1. 둘 다 상관 없음\t2. 여름에 뜨아\t3. 겨울에 아아메";
        string q4= "Q4. 탕수육 찍먹 vs 부먹\n1. 찍먹파\t2. 부먹파\t3. 주는대로...";
        string q5= "Q5. 평생 여름 vs 평생 겨울\n1. 평생 여름\t2. 평생 겨울\t3. 둘 다 싫어요";

        List<string> questionList = new List<string>(5);
        int[] highAnwList = { 2, 2, 3, 3, 2 };
        int[] midAnwList = { 1, 1, 1, 2, 3 };
        
        #endregion
        
        //답변
        int choice = 0;
        bool isNum = false;
        
        //리스트에 질문 5개 순서대로 추가
        questionList.Add(q1);
        questionList.Add(q2);
        questionList.Add(q3);
        questionList.Add(q4);
        questionList.Add(q5);
        
        
        //질문 5개 묻기
        while (currentQIdx < totalQCnt)
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine(questionList[currentQIdx]); //질문, 선택지 출력
            Console.WriteLine("------------------------------");
            Console.Write("선택(1~3) : ");
            
            //유효성 검사
            isNum = int.TryParse(Console.ReadLine(), out choice);

            if (!isNum || (choice <= 0 || choice > 3))
            {
                Console.WriteLine("잘못된 입력입니다! 감점!");
                score -= 5;
            }
            else
            {
                if (choice == highAnwList[currentQIdx]) score += 20;
                else if (choice == midAnwList[currentQIdx]) score += 10;
                else score += 0;
            }
            Console.WriteLine();
            currentQIdx++;
        }

        Console.WriteLine("결과... 두구두구두구...");
        Console.WriteLine();
        
        //결과 판단
        if (score > greatValue) //100~81
        {
            Console.Write("취향이 정말 잘 맞네요! 같이 이야기하면 즐거울 것 같아요! (•\u0300ᴗ•\u0301)و");
        }
        else if (score > goodValue) //80~61
        {
            Console.Write("꽤 비슷한 취향이네요! 친해지면 대화가 잘 통할 것 같아요! (｡•\u0300ᴗ-)\u2727");
        }
        else if (score > sosoValue) // 60~31
        {
            Console.Write("오~ 어느 정도 비슷한 취향을 가진 것 같아요! 좀 더 알아가 볼까요? (๑˃̵ᴗ˂̵)و");
        }
        else
        {
            Console.Write("저랑은 맞지 않으시네요... 다음 기회에! (\u00b4・ω・\uff40)");
        }

        Console.WriteLine($" (총점 : {score}점)");
        
    }
}