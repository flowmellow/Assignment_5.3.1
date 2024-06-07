/*
 1. You have a long flowerbed in which some of the plots are planted, and some are not. However, flowers cannot be planted in adjacent plots.
Given an integer array flowerbed containing 0's and 1's, where 0 means empty and 1 means not empty, and an integer n, return true if n new flowers can be planted in the flowerbed without violating the no-adjacent-flowers rule and false otherwise.
Example 1:
Input: flowerbed = [1,0,0,0,1], n = 1
Output: true

Example 2:
Input: flowerbed = [1,0,0,0,1], n = 2
Output: false
*/

namespace Assignment_5._3._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] flowerBed = { 1, 0, 0, 0, 1};                  
            int n = 2;
          
            Console.WriteLine(CanPlantFlower(flowerBed, n));
           

        }


        public static bool CanPlantFlower(int[] flowerBed, int n)
        {
            // edge cases
            if (flowerBed.Length == 1)
            {
                // No empty spots but no plats to plant, return true
                if (flowerBed[0] == 1 && n==0) return true;
                // One empty spot and at most 1 plant to plant, return true
                if (flowerBed[0] == 0 && n<=1) return true;

            }

            // Count of the valid spots
            int numAvailableSpots = 0;

            for (int i = 0; i < flowerBed.Length; i++)
            {
                // this spot is already taken up, continue
                if (flowerBed[i] == 1) continue;

                // If checking the first index, check if the right index is valid
                else if (flowerBed[i] == 0 && i==0 && isValid(flowerBed, i + 1))
                {
                    flowerBed[i] = 1;
                    n--;
                    numAvailableSpots++;
                }

                // If checking the last index, check if the left index is valid
                else if(flowerBed[i] == 0 && i == flowerBed.Length-1 && isValid(flowerBed, i - 1))
                {
                    flowerBed[i] = 1;
                    n--;
                    numAvailableSpots++;
                }

                // Otherwise check the left and right
                else if ((isValid(flowerBed,i-1)==true && isValid(flowerBed, i+1)== true))
                {
                    flowerBed[i] = 1;
                    n--;
                    numAvailableSpots++;
                }

            }
            // If we found enough (or more) empty spots, return true
            if (numAvailableSpots >= 0 && n == 0)
            {
                return true;
            }
            else
            {
                return false;
            }              
            

        }

        public static bool isValid(int[] flowerBed, int check)
        {
            if (check > flowerBed.Length - 1 || check < 0 || flowerBed[check] == 1)
            {
                return false;
            } 
            else
            {
                return true;
            }
            
        }

    }                         
}        
        
                  
    
    
       
 



        
