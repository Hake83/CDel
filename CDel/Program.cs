
/* CDel program, deletes previous iterations of CREO files in a directory
 * (*.asm; *.prt; *.drw) feel free to rename the .exe to whatever you wish to use
 * Copyright(C) 2018  Ryan S. Hake, Burger & Brown Engineering Inc.
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.If not, see<http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;


namespace CDel
{
    class Program
    {
        static void Main()
        {
            //Get the directory path
            string dir = Directory.GetCurrentDirectory();
            DirectoryInfo d = new DirectoryInfo(dir);

            //Get part file array from directory
            string[] prts = Directory.GetFiles(dir, "*.prt.*", SearchOption.TopDirectoryOnly);

            List<string> del1 = new List<string>();

           
            if (prts != null && prts.Length > 0)
            {

                for (int i = 0; i < prts.Length - 1; i++)
                {
                    for (int z = i + 1; z < prts.Length; z++)
                    {
                        string alpha = prts[i];
                        string beta = prts[z];
                        if (alpha.Split('.')[0] == beta.Split('.')[0])
                        {
                            int charlie = Convert.ToInt32(alpha.Split('.')[2]);
                            int delta = Convert.ToInt32(beta.Split('.')[2]);
                            if (charlie < delta)
                            {
                                del1.Add(prts[i]);

                            }
                            else
                            {
                                del1.Add(prts[z]);
                            }
                        }
                    }
                }
                del1 = del1.Distinct().ToList();
                foreach (string thingy in del1)
                {
                    File.Delete(thingy);
                }
            }




            //start of assembly checker
            string[] asm = Directory.GetFiles(dir, "*.asm.*", SearchOption.TopDirectoryOnly);

            List<string> del2 = new List<string>();

            if (asm != null && asm.Length > 0)
            {
                for (int i = 0; i < asm.Length; i++)
                {
                    for (int z = i + 1; z < asm.Length; z++)
                    {

                        string alpha = asm[i];
                        string beta = asm[z];
                        if (alpha.Split('.')[0] == beta.Split('.')[0])
                        {
                            int charlie = Convert.ToInt32(alpha.Split('.')[2]);
                            int delta = Convert.ToInt32(beta.Split('.')[2]);
                            if (charlie < delta)
                            {
                                del2.Add(asm[i]);

                            }
                            else
                            {
                                del2.Add(asm[z]);
                            }
                        }
                    }

                }
                del2 = del2.Distinct().ToList();
                foreach (string thing in del2)
                {
                    File.Delete(thing);
                }
            }





            // start of drawing files
            string[] drw = Directory.GetFiles(dir, "*.drw.*", SearchOption.TopDirectoryOnly);

      
           List<string> del3 = new List<string>();

            if (drw != null && drw.Length > 0)
            {
                for (int i = 0; i < drw.Length; i++)
                {
                    for (int z = i + 1; z < drw.Length; z++)
                    {
                        string alpha = drw[i];
                        string beta = drw[z];
                        if (alpha.Split('.')[0] == beta.Split('.')[0])
                        {
                            int charlie = Convert.ToInt32(alpha.Split('.')[2]);
                            int delta = Convert.ToInt32(beta.Split('.')[2]);

                            if (charlie < delta)
                            {
                                del3.Add(drw[i]);                                
                            }
                            else
                            {
                                del3.Add(drw[z]);
                            }

                        }
                    }
                    
                }

                del3 = del3.Distinct().ToList();
                foreach(string lister in del3)
                {
                    File.Delete(lister);
                }
            }

        }
    }
}
