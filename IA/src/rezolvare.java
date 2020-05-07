import java.util.HashMap;
import java.util.List;

public class rezolvare {
    public List<Integer> rez(int [][]graph , int s , int length)
    {
        int min;
        int curent = s;
        int ind;
        boolean[] visited =new boolean[graph.length];
        while(true) {
            min=0;
        for (int i = 0; i < length; ++i) {
            if(graph[curent][i] < min && visited[i])
            {
                ind = i;
            }
        }

            return null;
    }
    }
}
