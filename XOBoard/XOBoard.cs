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
        

        public XOBoard()
        {
            
            matrix = new string[,] {
                                     {"1","2","3"},
                                     {"4","5","6"},
                                     {"7","8","9"}};
            p1_score = 0;
            p2_score = 0;
        }
        public XOBoard(int size=3)
        {
            this.size = size;
            matrix = new string[size, size];
        }
        public void put()
        {
          
            int x;
            Random rnd = new Random();
            if (rnd.Next() % 2 == 0) System.Console.WriteLine("Player 1 play first");
            else System.Console.WriteLine("Player 2 play fisrt");
            for (int i = 0; i < size*size; i++)
            {
                do
                {
                    x = Convert.ToInt32(Console.ReadLine());
                    x--;
                    row = x / size;
                    col = size-1 - (x % size);
                    if(matrix[row,col]=="X"|| matrix[row, col] == "O")
                    {
                        System.Console.WriteLine("This place{0}{1} isnt avalid",row,col);
                    }


                } while (matrix[row, col] == "X" || matrix[row, col] == "O");
                if (i % 2 == 0) matrix[row, col] = "X".ToString();
                else matrix[row, col] = "O".ToString();
                Status();
            }
            System.Console.WriteLine("Tie");

        }

        public void Status()
        {
            int temp_row = 0;
            int temp_col = 0;
            int temp_cross = 0;

            for(int i = 0; i < size-1; i++)
            {
                for(int j = 0; j < size-1; j++)
                {
                    if (matrix[i, j] == matrix[i, j + 1]) temp_row++;
                    
                }
               
                if (temp_row == size)
                {
                    System.Console.WriteLine("Player {0} win", matrix[i,0]);
                    break;
                }
            }


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
            System.Console.ReadLine();
        }

    }
   

}
