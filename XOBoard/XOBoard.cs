using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOBoard
{
    class XOBoard
    {
        private int p1_score;
        private int p2_score;
        private String[,] matrix; 
        private int row;
        private int col;
        private int size;
        

        public XOBoard(int size=3)
        {
            this.size = size;
            matrix = new string[,] {
                                     {"1","2","3"},
                                     {"4","5","6"},
                                     {"7","8","9"}};
            p1_score = 0;
            p2_score = 0;
        }
        //public XOBoard(int size=3)
        //{
        //    this.size = size;
        //    matrix = new string[size, size];
        //}
        public void put()
        {
          
            int x;
            Random rnd = new Random();
            if (rnd.Next() % 2 == 0) System.Console.WriteLine("Player 1 play first");
            else System.Console.WriteLine("Player 2 play fisrt");
            for (int i = 0; i < size*size-1; i++)
            {
                
                do
                {
                    x = Convert.ToInt32(Console.ReadLine());
                    
                    row = --x / size;
                    col =  (x % size);
                    
                    if(matrix[row,col]=="X"|| matrix[row, col] == "O")
                    {
                        System.Console.WriteLine("This place{0}{1} isnt avalid",row,col);
                    }


                } while (matrix[row, col] == "X" || matrix[row, col] == "O");
                if (i % 2 == 0) matrix[row, col] = "X".ToString();
                else matrix[row, col] = "O".ToString();
                Display();
                
                Status();

            }
            System.Console.WriteLine("Tie");

        }

        public void Status()
        {
        if (matrix[0, 0] == matrix[0, 1] && matrix[0, 1] == matrix[0, 2]) System.Console.WriteLine("Player {0} win", matrix[0, 0]);
        if (matrix[1, 0] == matrix[1, 1] && matrix[1, 1] == matrix[1, 2]) System.Console.WriteLine("Player {0} win", matrix[1, 0]);
        if (matrix[2, 0] == matrix[2, 1] && matrix[2, 1] == matrix[2, 2]) System.Console.WriteLine("Player {0} win", matrix[2, 0]);
        if (matrix[0, 0] == matrix[1, 0] && matrix[1, 0] == matrix[2, 0]) System.Console.WriteLine("Player {0} win", matrix[0, 0]);
        if (matrix[0, 1] == matrix[1, 1] && matrix[0, 1] == matrix[2, 1]) System.Console.WriteLine("Player {0} win", matrix[0, 1]);
        if (matrix[0, 2] == matrix[1, 2] && matrix[1, 2] == matrix[2, 2]) System.Console.WriteLine("Player {0} win", matrix[0, 2]);
        if (matrix[0, 0] == matrix[1, 1] && matrix[1, 1] == matrix[2, 2]) System.Console.WriteLine("Player {0} win", matrix[0, 0]);
        if (matrix[0, 2] == matrix[1, 1] && matrix[1, 1] == matrix[2, 0]) System.Console.WriteLine("Player {0} win", matrix[0, 2]);


        }

        public void Display()
        {
            for(int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    System.Console.Write(matrix[i, j]);
                }
                System.Console.Write("\n");
            }
            
        }

    }
   

}
