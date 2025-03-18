namespace Practice0311;

class Student
    {
        public int num; // 번호
        public string name; // 이름
        public int age; // 나이
        public int height; // 키
        public bool hasWeightInfo; // 몸무게 정보 유무
        public int weight; // 몸무게
        public bool hasVisionInfo; // 시력 정보 유무
        public float visionLeft; //좌 시력
        public float visionRight; //우 시력
        public string region; // 거주지
        public bool military; //병역 의무 여부
        public string hobby; // 취미
        public string major; // 전공 
        public bool hasExperience; // 개발 및 게임 관련 산업 경험 여부


        public Student(int num, string name, int age, int height, bool hasWeightInfo, int weight,
                   bool hasVisionInfo, float visionLeft, float visionRight, string region,
                   bool military, string hobby, string major, bool hasExperience)
        {
            this.num = num;
            this.name = name;
            this.age = age;
            this.height = height;
            this.hasWeightInfo = hasWeightInfo;
            this.weight = weight;
            this.hasVisionInfo = hasVisionInfo;
            this.visionLeft = visionLeft;
            this.visionRight = visionRight;
            this.region = region;
            this.military = military;
            this.hobby = hobby;
            this.major = major;
            this.hasExperience = hasExperience;
        }

        public void PrintInfo()
        {
            //나이 : 
            //키 :
            //몸무게 :
            //시력(좌, 우) :
            //거주지 :
            //병역의무 여부 :
            //취미 :
            //전공 :
            //게임 개발 및 관련 산업 경험 여부 : 
            Console.WriteLine("{0}. {1}", num, name);
            Console.WriteLine("나이 : {0}세", age);
            Console.WriteLine("키 : {0}cm", height);
            Console.WriteLine("몸무게 : {0}", (hasWeightInfo ? weight.ToString("0.0") + "kg" : "밝히지 않음"));
            Console.WriteLine("시력(좌, 우) : {0}, {1}", (hasVisionInfo ? visionLeft.ToString() : "밝히지 않음"), (hasVisionInfo ? visionRight.ToString() : "밝히지 않음"));
            Console.WriteLine("거주지 : {0}", region);
            Console.WriteLine("병역의무 여부 : {0}", (military ? "O" : "X"));
            Console.WriteLine("취미 : {0}", hobby);
            Console.WriteLine("전공 : {0}", major);
            Console.WriteLine("게임 개발 및 관련 산업 경험 여부 : {0}", (hasExperience ? "O" : "X"));
            Console.WriteLine();




        }
    }

class TeamMember
{
    static void Main(string[] args)
    {
        Student smh = new Student(1, "성무현", 39, 176, true, 86, true, 1.0f, 1.0f, "인천", true, "그림 그리기", "게임 그래픽과", true);
        Student lmh = new Student(2, "이민호", 28, 165, true, 58, false, 0f, 0f, "인천", true, "게임, 영화 감상", "컴퓨터공학과", true);
        Student kjh = new Student(3, "김재현", 33, 170, false, 0, false, 0f, 0f, "안산", false, "게임", "기계공학과", false);
        Student ldh = new Student(4, "이도현", 26, 165, false, 0, true, -3.0f, -2.5f, "경기", true, "뜨개질, 게임", "컴퓨터공학과", true);
        Student bch = new Student(5, "백창현", 33, 174, false, 0, true, 0.1f, 0.1f, "경북", true, "게임, 요리", "전기기계과", false);

        Console.WriteLine("4조 팀원을 소개하겠습니다.\n");
        smh.PrintInfo();
        lmh.PrintInfo();
        kjh.PrintInfo();
        ldh.PrintInfo();
        bch.PrintInfo();

        Console.WriteLine("이상으로 소개를 마치겠습니다.\n감사합니다.");


    }
}