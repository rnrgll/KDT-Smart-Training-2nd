namespace Practice0324;

class Program
{
    //카트
    //속성
    //- 드리프트
    //- 가속도
    //- 커브
    //- 가속 시간
    //- 게이지 속도
    //- 레벨
    //- 등급
    //- 속성
    //- 꾸미기 가능 여부
    //- 액세서리...
    
    //메소드
    
    
    //등급
    public enum Grade{Normal, Epic, Rare, Legend}

    public enum AccessoryType
    {
        Paint,
        NumberPlate,
        Ora,
        Skid
    };
    
    //액세서리
    public abstract class Accessory
    {
        public string Name { get; set; } // 액세서리 이름
        public AccessoryType type { get; set; }//액세서리 종류

        public abstract void Equipped(); //착용
        public abstract void UnEquipped(); //착용 해제
    }
    
    
    
    //기본 카트
    public class Kart()
    {
        //공통 속성
        public int Speed { get; set; } //현재 속도
        public int Acceleration { get; set; }//가속도
        public int Drift { get; set; }//드리프트 성능
        public int Curve { get; set; } //커브 조작 성능
        public int BoostTime { get; set; } //가속 지속 시간
        public int GaugeSpeed { get; set; } //게이지 충전 속도
        //내구도
        
        
        public int Level { get; set; }//레벨
        public Grade Grade { get; set; }//등급
        
        public bool CanDecorate { get; set; }//꾸미기 가능 여부
        public List<Accessory> Accessories { get; private set; }//장착된 액세서리
        


        //공통 메소드
        
        //가속
        
        //브레이크
        
        //회전
        
        //드리프트
        
        //부스트 사용하기
        
        //부스트 게이지 충전
        
        
        //레벨업
        
        
        //액세서리 착용
        //액세서리 해제
        
        //내구도 닳기
        
        
        //수리
        
    }
    
    
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}