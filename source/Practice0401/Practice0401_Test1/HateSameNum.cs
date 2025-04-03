namespace Practice0401;

public class HateSameNum
{
    public List<int> Solution(List<int> array)
    {
        List<int> answer = new List<int>(array.Capacity);

        foreach (int n in array)
        {
            if (answer.Count == 0)
            {
                answer.Add(n);
                continue;
            }
            
            if(answer[answer.Count-1]==n) continue;
            
            answer.Add(n);
            
            
        }


        return answer;
    }
}