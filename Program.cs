internal class Program
{
    private static void Main(string[] args)
    {
        char[,] mat = new char[170, 1000];

        string[] lines = File.ReadAllLines("input.txt");
        char[] seps = { '-', '>' };
        int floor = 0;
        foreach (string line in lines)
        {
            string[] tokens = line.Split(seps, StringSplitOptions.RemoveEmptyEntries);

            string[] coord = tokens[0].Split(',');
            int x = int.Parse(coord[0]);
            int y = int.Parse(coord[1]);
            if(y > floor)
                floor = y;
            int xprev, yprev, xmax, xmin, ymax, ymin;
            for (int i = 1; i < tokens.Length; i++)
            {
                xprev = x;
                yprev = y;
                coord = tokens[i].Split(',');
                x = int.Parse(coord[0]);
                y = int.Parse(coord[1]);

                if(y > floor)
                    floor = y;

                if(xprev == x){
                    if(y < yprev){
                        ymin = y;
                        ymax = yprev;
                    }else{
                        ymin = yprev;
                        ymax = y;
                    }
                    for(int yy = ymin; yy <= ymax; yy++)
                    {
                        mat[yy, x] = '#';
                    }
                } else {
                    if(x < xprev){
                        xmin = x;
                        xmax = xprev;
                    }else{
                        xmin = xprev;
                        xmax = x;
                    }
                    for(int xx = xmin; xx <= xmax; xx++)
                    {
                        mat[y, xx] = '#';
                    }
                }
            }
        }

        floor+=2;
        for(int j = 0; j < 1000; j++)
            mat[floor, j] = '#';

        int count;
        bool finished = false;
        for(count = 0;!finished; count++)
        {
            int i = 0;
            int j = 500;
            bool canFall = true;
            while(canFall)
            {
                if(mat[i+1, j] == 0){
                    i++;
                }else if(mat[i+1, j-1] == 0){
                    i++;
                    j--;
                }else if(mat[i+1, j+1] == 0)
                {
                    i++;
                    j++;
                }else{
                    canFall = false;
                    mat[i, j] = 'o';
                }
            }
            finished = (i==0);
        }

        Console.WriteLine(count);

    }
}