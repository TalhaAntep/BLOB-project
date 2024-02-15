using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dna_deneme
{
    internal class Program
    {

        static void Main(string[] args)
        {


            string again = "input";
            while (again == "input")
            {
                Console.WriteLine();
             
                Console.WriteLine(">>>----<<< INPUT MENU >>>----<<<");
                Console.WriteLine("1 - To load from a file");
                Console.WriteLine("2 - To enter dna yourself");
                Console.WriteLine("3 - To create a new BLOB dna");
                Console.WriteLine();
                Console.Write("What is your choice?: ");
                int input_choose = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine();


                string dna_user = "";

                if (input_choose == 1)
                {

                    dna_user = System.IO.File.ReadAllText(@"dna.txt", Encoding.GetEncoding("windows-1254"));
                }

                else if (input_choose == 2)
                {
                    Console.Write("Please enter DNA: ");
                    dna_user = Console.ReadLine();
                }

                else if (input_choose == 3)
                {

                    dna_user = random_blob();
                }

                else
                {
                    Console.WriteLine("Invalid value");
                }

                again = "yes";

                int lenght = dna_user.Length;
                char[] dna_user_char = capitalize_and_char(dna_user);
                dna_user = "";

                for (int i = 0; i < lenght; i++)
                {
                    dna_user = dna_user + dna_user_char[i];

                }

                Console.Clear();

                while (again == "yes" || again == "YES" || again == "Yes" || again == "Y" || again == "y")

                {

                    Console.WriteLine();


                    Console.WriteLine(">>>----------<<< OPERATIION MENU >>>----------<<<");
                    Console.WriteLine("1  - To calculate of numbers of hydrogen bonds");
                    Console.WriteLine("2  - To check your DNA gene structure");
                    Console.WriteLine("3  - To check your DNA of BLOB organism");
                    Console.WriteLine("4  - To produce complement of a DNA sequence");
                    Console.WriteLine("5  - To determine amino acids");
                    Console.WriteLine("6  - To delete codons(delete n codons, starting from m.codon)");
                    Console.WriteLine("7  - To insert codon sequence from n. codon");
                    Console.WriteLine("8  - To find codon sequence from n. codon");
                    Console.WriteLine("9  - To reverse codon sequence from n. codon");
                    Console.WriteLine("10 - To find the number of genes");
                    Console.WriteLine("11 - To find the shortest gene");
                    Console.WriteLine("12 - To find the longest gene");
                    Console.WriteLine("13 - To find the most repeated nucleotide sequence");
                    Console.WriteLine("14 - To simulate BLOB generations");
                    Console.WriteLine();
                    Console.Write("What is your choice?: ");
                    int op_choose = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    switch (op_choose)
                    {

                        case 1:
                            {

                                int total_number_of_hydrogen_bond = 0;
                                int number_of_2hyd = 0;
                                int number_of_3hyd = 0;

                                for (int i = 0; i < dna_user.Length; i++)
                                {
                                    if (dna_user_char[i] == 'A' || dna_user_char[i] == 'T')
                                    {
                                        number_of_2hyd += 1;

                                        total_number_of_hydrogen_bond += 2;
                                    }
                                    else if (dna_user_char[i] == 'G' || dna_user_char[i] == 'C')
                                    {
                                        number_of_3hyd += 1;

                                        total_number_of_hydrogen_bond += 3;
                                    }
                                }

                                Console.WriteLine("DNA strand : " + dna_space(dna_user_char));
                                Console.WriteLine("Number of pairing with 2-hydrogen bonds: " + number_of_2hyd);
                                Console.WriteLine("Number of pairing with 3-hydrogen bonds: " + number_of_3hyd);
                                Console.WriteLine("Number of hydrogen bonds: " + total_number_of_hydrogen_bond);
                                break;
                            }
                        case 2:
                            {
                                bool error = structure(dna_user_char);
                                if (!error)
                                    Console.WriteLine("Gene structure is OK");
                                break;
                            }
                        case 3:
                            {
                                bool error = blob_or_not(dna_user_char);
                                if (error == false)
                                    Console.WriteLine("BLOB is OK");
                                break;
                            }
                        case 4:
                            {
                                bool error = structure(dna_user_char);
                                if (error == true)
                                {
                                    Console.WriteLine("Your DNA is wrong");
                                    break;
                                }
                                else
                                {

                                    Console.WriteLine("Dna strand : " + dna_space(dna_user_char));
                                    for (int i = 0; i < dna_user_char.Length; i++)
                                    {
                                        if (dna_user_char[i] == 'A')
                                            dna_user_char[i] = 'T';
                                        else if (dna_user_char[i] == 'T')
                                            dna_user_char[i] = 'A';
                                        else if (dna_user_char[i] == 'G')
                                            dna_user_char[i] = 'C';
                                        else if (dna_user_char[i] == 'C')
                                            dna_user_char[i] = 'G';
                                    }

                                    Console.WriteLine("Dna strand : " + dna_space(dna_user_char));

                                    Console.WriteLine();
                                    break;
                                }

                            }
                        case 5:
                            {
                                bool error = structure(dna_user_char);
                                if (error)
                                {
                                    Console.WriteLine("Your DNA is wrong");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("DNA strand  : " + dna_space(dna_user_char));
                                    Console.Write("Amino acids : ");
                                    string[] codonlist = new string[] { "ATG", "TAG", "TGA", "TAA", "GCT", "GCC", "GCA", "GCG", "CGT", "CGC", "CGA", "CGG", "AGA", "AGG", "AAT", "AAC", "GAT", "GAC", "TGT", "TGC", "CAA", "CAG", "GAA", "GAG", "GGT", "GGC", "GGA", "GGG", "CAT", "CAC", "ATT", "ATC", "ATA", "CTT", "CTC", "CTA", "CTG", "TTA", "TTG", "AAA", "AAG", "TTT", "TTC", "CCT", "CCC", "CCA", "CCG", "TCT", "TCC", "TCA", "TCG", "AGT", "AGC", "ACT", "ACC", "ACA", "ACG", "TGG", "TAT", "TAC", "GTT", "GTC", "GTA", "GTG" };
                                    string[] amino_acids = { "Met ", "END ", "END ", "END ", "Ala ", "Ala ", "Ala ", "Ala ", "Arg ", "Arg ", "Arg ", "Arg ", "Arg ", "Arg ", "Asn ", "Asn ", "Asp ", "Asp ", "Cys ", "Cys ", "Gln ", "Gln ", "Glu ", "Glu ", "Gly ", "Gly ", "Gly ", "Gly ", "His ", "His ", "Ile ", "Ile ", "Ile ", "Leu ", "Leu ", "Leu ", "Leu ", "Leu ", "Leu ", "Lys ", "Lys ", "Phe ", "Phe ", "Pro ", "Pro ", "Pro ", "Pro ", "Ser ", "Ser ", "Ser ", "Ser ", "Ser ", "Ser ", "Thr ", "Thr ", "Thr ", "Thr ", "Trp ", "Tyr ", "Tyr ", "Val ", "Val ", "Val ", "Val " };
                                    for (int i = 0; i < dna_user.Length; i += 3)
                                    {
                                        for (int j = 0; j < codonlist.Length; j++)
                                        {
                                            if (("" + dna_user_char[i] + dna_user_char[i + 1] + dna_user_char[i + 2]) == codonlist[j])
                                                Console.Write(amino_acids[j]);
                                        }
                                    }
                                    Console.WriteLine();
                                    break;
                                }
                            }

                        case 6:
                            {
                                bool error = structure(dna_user_char);
                                if (error == true)
                                {
                                    Console.WriteLine("Your DNA is wrong");
                                    break;
                                }
                                else
                                {


                                    Console.Write("How many codons will be deleted: ");
                                    int num_deleting = Convert.ToInt16(Console.ReadLine());
                                    Console.Write("Which codon is starting point: ");
                                    int start_codon = Convert.ToInt16(Console.ReadLine());
                                    Console.WriteLine();
                                    Console.WriteLine("Your DNA : " + dna_space(dna_user_char));
                                    for (int i = 3 * (start_codon - 1); i < dna_user.Length - 3 * num_deleting; i++)
                                    {
                                        dna_user_char[i] = dna_user[i + 3 * num_deleting];
                                    }
                                    for (int i = dna_user.Length - 1; i > dna_user.Length - 1 - 3 * num_deleting; i--)
                                        dna_user_char[i] = ' ';


                                    Console.WriteLine("Delete " + num_deleting + " codonds, starting from " + start_codon + ". codon");
                                    Console.WriteLine("New DNA  : " + dna_space(dna_user_char));


                                    break;
                                }

                            }


                        case 7:
                            {
                                bool error = structure(dna_user_char);
                                if (error == true)
                                {
                                    Console.WriteLine("Your DNA is wrong");
                                    break;
                                }
                                else
                                {

                                    Console.Write("Please enter a new codons to add: ");
                                    string codons_to_add = Console.ReadLine();
                                    char[] codons_add_list = capitalize_and_char(codons_to_add);
                                    for (int i = 0; i < codons_add_list.Length; i++)
                                    {
                                        if (codons_add_list[i] == 'a')
                                            codons_add_list[i] = 'A';
                                        else if (codons_add_list[i] == 't')
                                            codons_add_list[i] = 'T';
                                        else if (codons_add_list[i] == 'g')
                                            codons_add_list[i] = 'G';
                                        else if (codons_add_list[i] == 'c')
                                            codons_add_list[i] = 'C';
                                    }

                                    Console.Write("Insert from n. codon: ");
                                    int n = Convert.ToInt16(Console.ReadLine());
                                    Console.WriteLine();
                                    Console.WriteLine("Dna strand     : " + dna_space(dna_user_char));
                                    Console.WriteLine("Codon sequence : " + dna_space(codons_add_list));
                                    Console.WriteLine("Starting from  :" + n);
                                    dna_user_char = new char[dna_user.Length + codons_to_add.Length];

                                    for (int i = 0; i < dna_user.Length; i++)
                                    {
                                        dna_user_char[i] = dna_user[i];
                                    }
                                    for (int i = 0; i < dna_user.Length; i++)
                                    {
                                        if (dna_user_char[i] == 'a')
                                            dna_user_char[i] = 'A';
                                        else if (dna_user_char[i] == 't')
                                            dna_user_char[i] = 'T';
                                        else if (dna_user_char[i] == 'g')
                                            dna_user_char[i] = 'G';
                                        else if (dna_user_char[i] == 'c')
                                            dna_user_char[i] = 'C';
                                    }

                                    char[] temp_char = new char[177];
                                    int k = 0;
                                    for (int i = 3 * (n - 1); i < dna_user_char.Length; i++)
                                    {
                                        temp_char[k] = dna_user_char[i];
                                        k++;
                                    }
                                    k = 0;
                                    for (int i = 3 * (n - 1); i < 3 * (n - 1) + codons_add_list.Length; i++)
                                    {
                                        dna_user_char[i] = codons_add_list[k];
                                        k++;
                                    }
                                    k = 0;
                                    for (int i = 3 * (n - 1) + codons_add_list.Length; i < dna_user.Length + codons_to_add.Length; i++)
                                    {
                                        dna_user_char[i] = temp_char[k];
                                        k++;
                                    }
                                    Console.WriteLine("Dna strand     : " + dna_space(dna_user_char));


                                    break;
                                }
                            }
                        case 8:
                            {
                                bool error = structure(dna_user_char);
                                if (error == true)
                                {
                                    Console.WriteLine("Your DNA is wrong");
                                    break;
                                }
                                else
                                {
                                    Console.Write("Please enter a codon sequence to find : ");
                                    string codons = Console.ReadLine();
                                    char[] codons_list = capitalize_and_char(codons);
                                    for (int i = 0; i < codons_list.Length; i++)
                                    {
                                        if (codons_list[i] == 'a')
                                            codons_list[i] = 'A';
                                        else if (codons_list[i] == 't')
                                            codons_list[i] = 'T';
                                        else if (codons_list[i] == 'g')
                                            codons_list[i] = 'G';
                                        else if (codons_list[i] == 'c')
                                            codons_list[i] = 'C';
                                    }
                                    Console.Write("Please enter the starting codon to research :");
                                    int n = Convert.ToInt16(Console.ReadLine());
                                    Console.WriteLine();
                                    Console.WriteLine("Dna strand     : " + dna_space(dna_user_char));
                                    Console.WriteLine("Codon sequence : " + dna_space(codons_list));
                                    Console.WriteLine("Starting from  : " + n);
                                    bool boolean = false;
                                    int num_codons = codons_list.Length / 3;
                                    int k = 0;
                                    int num_true = 0;
                                    for (int i = 3 * (n - 1); i < dna_user_char.Length; i += 3)
                                    {
                                        if (!(i + num_codons * 3 > dna_user_char.Length))
                                        {
                                            for (int j = 0; j < num_codons * 3; j += 3)
                                            {
                                                if ((dna_user_char[i + j] == codons_list[j]) && (dna_user_char[i + j + 1] == codons_list[j + 1]) && (dna_user_char[i + j + 2] == codons_list[j + 2]))
                                                {
                                                    num_true++;
                                                    if (num_true == num_codons)
                                                        break;
                                                }
                                                else
                                                    num_true = 0;
                                            }
                                            if (num_true == num_codons)
                                            {
                                                boolean = true;
                                                break;
                                            }
                                        }
                                        k++;
                                    }
                                    if (boolean)
                                        Console.WriteLine("Result         : " + (k + n));

                                    else
                                        Console.WriteLine("Result         : -1 (not found)");


                                    break;
                                }
                            }

                        case 9:
                            {
                                bool error = structure(dna_user_char);
                                if (error == true)
                                {
                                    Console.WriteLine("Your DNA is wrong");
                                    break;
                                }
                                else
                                {
                                    Console.Write("Reverse from m. codon: ");
                                    int start_codon = Convert.ToInt16(Console.ReadLine());

                                    Console.Write("How many codons: ");
                                    int num_reverse = Convert.ToInt32(Console.ReadLine());

                                    Console.WriteLine("Dna strand      : " + dna_space(dna_user_char));

                                    Console.WriteLine("Starting from   :" + start_codon);
                                    char[] temp_char = new char[num_reverse * 3];
                                    for (int i = 0; i < num_reverse * 3; i++)
                                        temp_char[i] = dna_user_char[i + 3 * (start_codon - 1)];
                                    int k = 3 * num_reverse - 1;
                                    for (int i = 3 * (start_codon - 1); i < 3 * (start_codon - 1) + 3 * num_reverse; i += 3)
                                    {
                                        dna_user_char[i] = temp_char[k - 2];
                                        dna_user_char[i + 1] = temp_char[k - 1];
                                        dna_user_char[i + 2] = temp_char[k];
                                        k -= 3;
                                    }
                                    Console.WriteLine("Dna strand      : " + dna_space(dna_user_char));

                                    break;

                                }
                            }
                        case 10:
                            {
                                bool error = structure(dna_user_char);
                                if (error == true)
                                {
                                    Console.WriteLine("Your DNA is wrong");
                                    break;
                                }
                                else
                                {
                                    int counter = 0;
                                    for (int i = 0; i < dna_user_char.Length; i += 3)
                                    {
                                        if (dna_user_char[i] == 'A' && dna_user_char[i + 1] == 'T' && dna_user_char[i + 2] == 'G')
                                            counter++;
                                    }
                                    Console.WriteLine("Dna strand       : " + dna_space(dna_user_char));
                                    Console.WriteLine("Nnumber of genes : " + counter);
                                    break;
                                }
                            }
                        case 12:
                            {

                                bool error = structure(dna_user_char);
                                if (error == true)
                                {
                                    Console.WriteLine("Your DNA is wrong");
                                    break;
                                }
                                else
                                {

                                    char[] longest_sequence = { };
                                    int longest_number = 0;

                                    int position = 0;
                                    int max = 0;


                                    for (int i = 0; i < dna_user_char.Length; i += 3)
                                    {
                                        char[] sequence = new char[dna_user_char.Length];
                                        int counter = 0;

                                        if (dna_user_char[i] == 'A' && dna_user_char[i + 1] == 'T' && dna_user_char[i + 2] == 'G')
                                        {
                                            for (int j = i; j < dna_user_char.Length; j += 3)
                                            {
                                                sequence[3 * counter] = dna_user_char[j]; sequence[3 * counter + 1] = dna_user_char[j + 1]; sequence[3 * counter + 2] = dna_user_char[j + 2];
                                                counter++;
                                                if ((dna_user_char[j] == 'T' && dna_user_char[j + 1] == 'A' && dna_user_char[j + 2] == 'A') || (dna_user_char[j] == 'T' && dna_user_char[j + 1] == 'G' && dna_user_char[j + 2] == 'A') || (dna_user_char[j] == 'T' && dna_user_char[j + 1] == 'A' && dna_user_char[j + 2] == 'G'))
                                                {

                                                    if (counter > max)
                                                    {
                                                        max = counter;
                                                        longest_number = counter;
                                                        longest_sequence = sequence;
                                                        position = j - 3 * counter;//this is 1 less from to must be
                                                        i = j - 3;

                                                    }
                                                    break;
                                                }

                                            }

                                        }
                                    }
                                    Console.WriteLine("Dna strand          : " + dna_space(dna_user_char));
                                    Console.WriteLine("Longest gene        : " + dna_space(longest_sequence));
                                    Console.WriteLine("Number of codons    : " + longest_number);
                                    Console.WriteLine("Position of the gene: " + (position / 3 + 2));//2 because we are counting 1 less from j and 1 less from substraction operation


                                    break;
                                }
                            }
                        case 11:
                            {

                                bool error = structure(dna_user_char);
                                if (error == true)
                                {
                                    Console.WriteLine("Your DNA is wrong");
                                    break;
                                }
                                else
                                {

                                    char[] shortest_sequence = { };
                                    int shortest_number = 0;

                                    int position = 0;
                                    int min = 100;


                                    for (int i = 0; i < dna_user_char.Length; i += 3)
                                    {
                                        char[] sequence = new char[dna_user_char.Length];
                                        int counter = 0;

                                        if (dna_user_char[i] == 'A' && dna_user_char[i + 1] == 'T' && dna_user_char[i + 2] == 'G')
                                        {
                                            for (int j = i; j < dna_user_char.Length; j += 3)
                                            {
                                                sequence[3 * counter] = dna_user_char[j]; sequence[3 * counter + 1] = dna_user_char[j + 1]; sequence[3 * counter + 2] = dna_user_char[j + 2];
                                                counter++;
                                                if ((dna_user_char[j] == 'T' && dna_user_char[j + 1] == 'A' && dna_user_char[j + 2] == 'A') || (dna_user_char[j] == 'T' && dna_user_char[j + 1] == 'G' && dna_user_char[j + 2] == 'A') || (dna_user_char[j] == 'T' && dna_user_char[j + 1] == 'A' && dna_user_char[j + 2] == 'G'))
                                                {

                                                    if (counter < min)
                                                    {
                                                        min = counter;
                                                        shortest_number = counter;
                                                        shortest_sequence = sequence;
                                                        position = j - 3 * counter;//this is 1 less from to must be
                                                        i = j - 3;

                                                    }
                                                    break;
                                                }

                                            }

                                        }
                                    }
                                    Console.WriteLine("Dna strand          : " + dna_space(dna_user_char));
                                    Console.WriteLine("Longest gene        : " + dna_space(shortest_sequence));
                                    Console.WriteLine("Number of codons    : " + shortest_number);
                                    Console.WriteLine("Position of the gene: " + (position / 3 + 2));//2 because we are counting 1 less from j and 1 less from abstraction operation


                                    break;
                                }
                            }
                        case 13:
                            {
                                string repeat = "";
                                char a;
                                string store1repeat = "";
                                int count_result = 0;
                                int count = 0;
                                string store_result = "";

                                Console.Write("Enter a number of nucletide which more repeated: ");
                                int num_repeat = Convert.ToInt16(Console.ReadLine());
                                Console.WriteLine();

                                Console.WriteLine("Dna strand      : " + dna_space(dna_user_char));
                                for (int k = 0; k < (dna_user_char.Length) - (num_repeat - 1); k++)
                                {
                                    for (int i = 0; i < (dna_user_char.Length) - (num_repeat - 1); i++)
                                    {
                                        int x = num_repeat;
                                        while (x != 0)
                                        {
                                            a = dna_user_char[i + num_repeat - x];
                                            x--;
                                            repeat = repeat + a;

                                        }
                                        if (k == i)
                                        {
                                            store1repeat = repeat;
                                        }
                                        if (store1repeat == repeat)
                                        {
                                            count++;
                                            i = i + num_repeat - 1;
                                        }


                                        repeat = "";

                                    }

                                    if (count > count_result)
                                    {
                                        store_result = store1repeat;
                                        count_result = count;
                                    }
                                    count = 0;
                                    store1repeat = "";

                                }
                                Console.WriteLine();
                                Console.WriteLine("Enter number of nucletide: " + num_repeat);
                                Console.WriteLine("Most repeated sequence   : " + store_result);
                                Console.WriteLine("Frequency                : " + count_result);
                                break;
                            }

                        case 14:
                            {
                                bool error = blob_or_not(dna_user_char);
                                if (error == true)
                                {
                                    Console.WriteLine("Your DNA is wrong");
                                    break;
                                }
                                else
                                {
                                    char[] blob_1 = dna_user_char;
                                    for (int a = 1; a < 11; a++)

                                    {

                                        char[] blob_2;
                                        char[] blob_3;

                                        do
                                        {
                                            blob_2 = capitalize_and_char(random_blob());
                                        } while (gender(blob_1) == "XY" && gender(blob_2) == "XY" || gender(blob_1) == "XX" && gender(blob_2) == "XX");

                                        blob_3 = new char[150];


                                        blob_3[0] = 'A'; blob_3[1] = 'T'; blob_3[2] = 'G'; blob_3[3] = blob_1[3]; blob_3[4] = blob_1[4]; blob_3[5] = blob_1[5]; blob_3[6] = blob_2[6]; blob_3[7] = blob_2[7]; blob_3[8] = blob_2[8]; blob_3[9] = 'T'; blob_3[10] = 'A'; blob_3[11] = 'G';



                                        int which_nucleotid = 12;
                                        char[] longer_array = find_longest_array(blob_1, blob_2);


                                        for (int i = 2; i <= find_max(find_gene_number(blob_1), find_gene_number(blob_2)); i += 1)
                                        {


                                            if (i % 2 == 0 && i < find_gene_number(blob_1))
                                            {
                                                char[] gene_to_add = find_gene(blob_1, i);

                                                for (int j = 0; j < 150; j += 3)
                                                {
                                                    blob_3[which_nucleotid] = gene_to_add[j]; blob_3[which_nucleotid + 1] = gene_to_add[j + 1]; blob_3[which_nucleotid + 2] = gene_to_add[j + 2];
                                                    which_nucleotid += 3;
                                                    if (gene_to_add[j] == 'T' && gene_to_add[j + 1] == 'A' && gene_to_add[j + 2] == 'G' || gene_to_add[j] == 'T' && gene_to_add[j + 1] == 'G' && gene_to_add[j + 2] == 'A' || gene_to_add[j] == 'T' && gene_to_add[j + 1] == 'A' && gene_to_add[j + 2] == 'A')
                                                        break;
                                                }
                                            }
                                            else if (i % 2 == 1 && i < find_gene_number(blob_2))
                                            {
                                                char[] gene_to_add = find_gene(blob_2, i);

                                                for (int j = 0; j < 150; j += 3)
                                                {
                                                    blob_3[which_nucleotid] = gene_to_add[j]; blob_3[which_nucleotid + 1] = gene_to_add[j + 1]; blob_3[which_nucleotid + 2] = gene_to_add[j + 2];
                                                    which_nucleotid += 3;
                                                    if (gene_to_add[j] == 'T' && gene_to_add[j + 1] == 'A' && gene_to_add[j + 2] == 'G' || gene_to_add[j] == 'T' && gene_to_add[j + 1] == 'G' && gene_to_add[j + 2] == 'A' || gene_to_add[j] == 'T' && gene_to_add[j + 1] == 'A' && gene_to_add[j + 2] == 'A')
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                for (int j = i; j <= find_max(find_gene_number(blob_1), find_gene_number(blob_2)); j += 1)
                                                {
                                                    char[] gene_to_add = find_gene(longer_array, j);

                                                    for (int k = 0; k < 150; k += 3)
                                                    {
                                                        try
                                                        {
                                                            blob_3[which_nucleotid] = gene_to_add[k]; blob_3[which_nucleotid + 1] = gene_to_add[k + 1]; blob_3[which_nucleotid + 2] = gene_to_add[k + 2];
                                                            which_nucleotid += 3;
                                                            if (gene_to_add[k] == 'T' && gene_to_add[k + 1] == 'A' && gene_to_add[k + 2] == 'G' || gene_to_add[k] == 'T' && gene_to_add[k + 1] == 'G' && gene_to_add[k + 2] == 'A' || gene_to_add[k] == 'T' && gene_to_add[k + 1] == 'A' && gene_to_add[k + 2] == 'A')
                                                                break;
                                                        }
                                                        catch
                                                        { break; }
                                                    }

                                                }
                                                break;
                                            }



                                        }

                                        int counter = 0;
                                        for (int i = 0; i < blob_3.Length; i += 3)
                                        {
                                            if (blob_3[i] == 'G' && blob_3[i + 1] == 'G' && blob_3[i + 2] == 'G' || blob_3[i] == 'C' && blob_3[i + 1] == 'C' && blob_3[i + 2] == 'C' || blob_3[i] == 'C' && blob_3[i + 1] == 'G' && blob_3[i + 2] == 'C' || blob_3[i] == 'C' && blob_3[i + 1] == 'C' && blob_3[i + 2] == 'G' || blob_3[i] == 'G' && blob_3[i + 1] == 'C' && blob_3[i + 2] == 'C' || blob_3[i] == 'C' && blob_3[i + 1] == 'G' && blob_3[i + 2] == 'G' || blob_3[i] == 'G' && blob_3[i + 1] == 'C' && blob_3[i + 2] == 'G' || blob_3[i] == 'G' && blob_3[i + 1] == 'G' && blob_3[i + 2] == 'C')
                                                counter++;
                                        }
                                        double ratio = ((double)counter / find_codon_number(blob_3) * 100);


                                        Console.WriteLine("Generation   " + a);
                                        Console.WriteLine("BLOB1-" + gender(blob_1) + " = " + dna_space(blob_1));
                                        Console.WriteLine("BLOB2-" + gender(blob_2) + " = " + dna_space(blob_2));
                                        Console.WriteLine("BLOB3-" + gender(blob_3) + " = " + dna_space(blob_3));
                                        Console.WriteLine("BLOB3 faulty codons ratio : " + counter + "/" + find_codon_number(blob_3) + " : %" + ratio);
                                        if (ratio >= 10)
                                        {
                                            Console.WriteLine("Newborn dies. Generations are over.");
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine();
                                            blob_1 = blob_3;
                                            Console.ReadLine();
                                        }
                                    }
                                    break;
                                }
                            }







                        default:
                            {
                                Console.WriteLine("Please enter a valid value");
                                break;
                            }


                    }
                    Console.WriteLine();
                    Console.WriteLine("Do you want to do another operation? (please enter yes or no) ");
                    Console.Write("If you want to input again enter 'input' :   ");
                    again = Console.ReadLine();
                    Console.Clear();



                }

            }
            Console.WriteLine("-----<<< END >>>-----");
            Console.ReadLine();
        }
        static char[] capitalize_and_char(string dna_user)
        {
            char[] dna_user_char = new char[dna_user.Length];
            for (int i = 0; i < dna_user.Length; i++)
            {
                dna_user_char[i] = dna_user[i];
            }
            for (int i = 0; i < dna_user.Length; i++)
            {
                if (dna_user_char[i] == 'a')
                    dna_user_char[i] = 'A';
                else if (dna_user_char[i] == 't')
                    dna_user_char[i] = 'T';
                else if (dna_user_char[i] == 'g')
                    dna_user_char[i] = 'G';
                else if (dna_user_char[i] == 'c')
                    dna_user_char[i] = 'C';
            }

            return dna_user_char;
        }
        static string random_blob()
        {
            Random random = new Random();
            int num_gene = random.Next(2, 8);
            char[] nucleotids = { 'A', 'G', 'C', 'T' };
            string dna_user = "ATG";
            int number_for_gender_1;
            int number_for_gender_2;
            do
            {
                number_for_gender_1 = random.Next(4);
                number_for_gender_2 = random.Next(4);

            } while (number_for_gender_1 == 1 && number_for_gender_2 == 1 || number_for_gender_1 == 2 && number_for_gender_2 == 2 || number_for_gender_1 == 1 && number_for_gender_2 == 2 || number_for_gender_1 == 2 && number_for_gender_2 == 1);

            dna_user = dna_user + nucleotids[number_for_gender_1] + nucleotids[number_for_gender_1] + nucleotids[number_for_gender_1] + nucleotids[number_for_gender_2] + nucleotids[number_for_gender_2] + nucleotids[number_for_gender_2] + "TAG";

            for (int i = 2; i <= num_gene; i++)
            {
                dna_user += "ATG";
                int num_codons = random.Next(1, 7);

                for (int j = 1; j <= num_codons; j++)
                {
                    int random_number = random.Next(4);
                    int random_number1 = random.Next(4);
                    int random_number2 = random.Next(4);

                    if (!((nucleotids[random_number] == 'A' && nucleotids[random_number1] == 'T' && nucleotids[random_number2] == 'G') || (nucleotids[random_number] == 'T' && nucleotids[random_number1] == 'A' && nucleotids[random_number2] == 'A') || (nucleotids[random_number] == 'T' && nucleotids[random_number1] == 'A' && nucleotids[random_number2] == 'G') || (nucleotids[random_number] == 'T' && nucleotids[random_number1] == 'G' && nucleotids[random_number2] == 'A')))
                    {
                        dna_user = dna_user + nucleotids[random_number] + nucleotids[random_number1] + nucleotids[random_number2];
                    }
                    else
                        j--;
                }
                dna_user += "T";
                int another_random_number = random.Next(2);
                if (another_random_number == 1)
                    dna_user += "GA";
                else
                {
                    dna_user += "A";
                    another_random_number = random.Next(2);
                    dna_user += nucleotids[another_random_number];
                }
            }
            return dna_user;
        }
        static bool blob_or_not(char[] dna_user_char)
        {
            bool error = false;
            int number_start = 0;
            int number_end = 0;

            if (dna_user_char.Length % 3 != 0)
            { Console.WriteLine("Codon structure error"); error = true; }
            else if (dna_user_char.Length < 21)
            { Console.WriteLine("Number of genes error"); error = true; }
            else if (!(dna_user_char[0] == 'A' && dna_user_char[1] == 'T' && dna_user_char[2] == 'G'))
            { Console.WriteLine("Gene structure error"); error = true; }
            else if (!((dna_user_char[dna_user_char.Length - 3] == 'T' && dna_user_char[dna_user_char.Length - 2] == 'A' && dna_user_char[dna_user_char.Length - 1] == 'A') || (dna_user_char[dna_user_char.Length - 3] == 'T' && dna_user_char[dna_user_char.Length - 2] == 'G' && dna_user_char[dna_user_char.Length - 1] == 'A') || (dna_user_char[dna_user_char.Length - 3] == 'T' && dna_user_char[dna_user_char.Length - 2] == 'A' && dna_user_char[dna_user_char.Length - 1] == 'G')))
            { Console.WriteLine("Gene structure error"); error = true; }
            else
            {
                for (int i = 0; i < dna_user_char.Length; i++)
                {
                    if (!(dna_user_char[i] == 'A' || dna_user_char[i] == 'T' || dna_user_char[i] == 'G' || dna_user_char[i] == 'C' || dna_user_char[i] == ' '))
                    {
                        Console.WriteLine("Gene structure error");
                        error = true;
                    }
                }

                for (int i = 0; i < dna_user_char.Length; i += 3)
                {
                    if (dna_user_char[i] == 'A' && dna_user_char[i + 1] == 'T' && dna_user_char[i + 2] == 'G')
                    {
                        number_start++;
                        if ((dna_user_char[i + 3] == 'T' && dna_user_char[i + 4] == 'A' && dna_user_char[i + 5] == 'A') || (dna_user_char[i + 3] == 'T' && dna_user_char[i + 4] == 'A' && dna_user_char[i + 5] == 'G') || (dna_user_char[i + 3] == 'T' && dna_user_char[i + 4] == 'G' && dna_user_char[i + 5] == 'A'))
                        {
                            error = true;
                            Console.WriteLine("Gene structure error");
                        }
                    }
                    else if ((dna_user_char[i] == 'T' && dna_user_char[i + 1] == 'A' && dna_user_char[i + 2] == 'A') || (dna_user_char[i] == 'T' && dna_user_char[i + 1] == 'G' && dna_user_char[i + 2] == 'A') || (dna_user_char[i] == 'T' && dna_user_char[i + 1] == 'A' && dna_user_char[i + 2] == 'G'))
                        number_end++;
                    if (number_start == number_end + 2)
                    { Console.WriteLine("Gene structure error"); error = true; }
                    else if (number_end == number_start + 1)
                    { Console.WriteLine("Gene structure error"); error = true; }
                }

                if (!(number_start == number_end))
                { Console.WriteLine("Gene structure error"); error = true; }

                else if (!((dna_user_char[3] == 'T' && dna_user_char[4] == 'T' && dna_user_char[5] == 'T') || (dna_user_char[3] == 'A' && dna_user_char[4] == 'A' && dna_user_char[5] == 'A') || (dna_user_char[3] == 'G' && dna_user_char[4] == 'G' && dna_user_char[5] == 'G') || (dna_user_char[3] == 'C' && dna_user_char[4] == 'C' && dna_user_char[5] == 'C')))
                { Console.WriteLine("Gender error"); error = true; }
                else if (!((dna_user_char[6] == 'T' && dna_user_char[7] == 'T' && dna_user_char[8] == 'T') || (dna_user_char[6] == 'A' && dna_user_char[7] == 'A' && dna_user_char[8] == 'A') || (dna_user_char[6] == 'G' && dna_user_char[7] == 'G' && dna_user_char[8] == 'G') || (dna_user_char[6] == 'C' && dna_user_char[7] == 'C' && dna_user_char[8] == 'C')))
                { Console.WriteLine("Gender error"); error = true; }
                else if ((dna_user_char[3] == 'G' && dna_user_char[4] == 'G' && dna_user_char[5] == 'G' && dna_user_char[6] == 'C' && dna_user_char[7] == 'C' && dna_user_char[8] == 'C') || (dna_user_char[3] == 'C' && dna_user_char[4] == 'C' && dna_user_char[5] == 'C' && dna_user_char[6] == 'G' && dna_user_char[7] == 'G' && dna_user_char[8] == 'G'))
                { Console.WriteLine("Gender error"); error = true; }
                else if (!(dna_user_char[9] == 'T' && dna_user_char[10] == 'A' && dna_user_char[11] == 'G'))
                { Console.WriteLine("Gender error"); error = true; }


            }
            return error;
        }
        static bool structure(char[] dna_user_char)
        {
            bool error = false;
            int number_start = 0;
            int number_end = 0;
            if (dna_user_char.Length % 3 != 0 || dna_user_char.Length < 6)
            { Console.WriteLine("Codon structure error"); error = true; }
            else
            {
                for (int i = 0; i < dna_user_char.Length; i += 3)
                {
                    if (dna_user_char[i] == 'A' && dna_user_char[i + 1] == 'T' && dna_user_char[i + 2] == 'G')
                        number_start++;
                    else if ((dna_user_char[i] == 'T' && dna_user_char[i + 1] == 'A' && dna_user_char[i + 2] == 'A') || (dna_user_char[i] == 'T' && dna_user_char[i + 1] == 'G' && dna_user_char[i + 2] == 'A') || (dna_user_char[i] == 'T' && dna_user_char[i + 1] == 'A' && dna_user_char[i + 2] == 'G'))
                        number_end++;
                    if (number_start == number_end + 2)
                        error = true;
                    else if (number_end == number_start + 1)
                        error = true;
                }
                if (!(number_start == number_end))
                    error = true;

                for (int i = 0; i < dna_user_char.Length; i++)
                {
                    if (!(dna_user_char[i] == 'A' || dna_user_char[i] == 'T' || dna_user_char[i] == 'G' || dna_user_char[i] == 'C' || dna_user_char[i] == ' '))
                    {
                        error = true;
                    }
                }

                if (error == true)
                    Console.WriteLine("Gene structure error");
                else if (!(dna_user_char[0] == 'A' && dna_user_char[1] == 'T' && dna_user_char[2] == 'G'))
                { Console.WriteLine("Gene structure error"); error = true; }
                else if (!((dna_user_char[dna_user_char.Length - 3] == 'T' && dna_user_char[dna_user_char.Length - 2] == 'A' && dna_user_char[dna_user_char.Length - 1] == 'A') || (dna_user_char[dna_user_char.Length - 3] == 'T' && dna_user_char[dna_user_char.Length - 2] == 'G' && dna_user_char[dna_user_char.Length - 1] == 'A') || (dna_user_char[dna_user_char.Length - 3] == 'T' && dna_user_char[dna_user_char.Length - 2] == 'A' && dna_user_char[dna_user_char.Length - 1] == 'G')))
                { Console.WriteLine("Gene structure error"); error = true; }

            }
            return error;
        }
        static string dna_space(char[] dna_user_char)
        {
            string dna_user_space = "";
            for (int i = 0; i < dna_user_char.Length; i++)
            {
                dna_user_space = dna_user_space + dna_user_char[i];
                if (i % 3 == 2)
                    dna_user_space += " ";
            }
            return dna_user_space;
        }

        static string gender(char[] dna_user_char)
        {
            string gend = "XY";
            if ((dna_user_char[3] == 'A' && dna_user_char[4] == 'A' && dna_user_char[5] == 'A') && (dna_user_char[6] == 'A' && dna_user_char[7] == 'A' && dna_user_char[8] == 'A'))
            {
                gend = "XX";
            }
            else if ((dna_user_char[3] == 'T' && dna_user_char[4] == 'T' && dna_user_char[5] == 'T') && (dna_user_char[6] == 'T' && dna_user_char[7] == 'T' && dna_user_char[8] == 'T'))
            {
                gend = "XX";
            }
            else if ((dna_user_char[3] == 'A' && dna_user_char[4] == 'A' && dna_user_char[5] == 'A') && (dna_user_char[6] == 'T' && dna_user_char[7] == 'T' && dna_user_char[8] == 'T'))
            {
                gend = "XX";
            }
            else if ((dna_user_char[3] == 'T' && dna_user_char[4] == 'T' && dna_user_char[5] == 'T') && (dna_user_char[6] == 'A' && dna_user_char[7] == 'A' && dna_user_char[8] == 'A'))
            {
                gend = "XX";
            }
            else
                gend = "XY";
            return gend;
        }

        static char[] find_longest_array(char[] array1, char[] array2)
        {
            if (array1.Length > array2.Length)
                return array1;
            else
                return array2;


        }
        static int find_max(int a, int b)
        {
            int c;
            if (a < b)
                c = b;
            else
                c = a;
            return c;
        }
        static int find_gene_number(char[] array)
        {

            int counter = 0;
            for (int i = 0; i < array.Length; i += 3)
            {
                if (array[i] == 'A' && array[i + 1] == 'T' && array[i + 2] == 'G')
                    counter++;
            }
            return counter;
        }
        static char[] find_gene(char[] array1, int which_gene)
        {
            char[] temp = new char[array1.Length];

            int number = 0;
            for (int i = 0; i < array1.Length; i += 3)
            {
                temp = new char[array1.Length];
                if (array1[i] == 'A' && array1[i + 1] == 'T' && array1[i + 2] == 'G')
                {
                    temp[i] = 'A'; temp[i + 1] = 'T'; temp[i + 2] = 'G';
                    for (int j = 0; j < array1.Length; j += 3)
                    {
                        temp[j] = array1[j + i]; temp[j + 1] = array1[j + i + 1]; temp[j + 2] = array1[j + i + 2];
                        if (array1[j + i] == 'T' && array1[j + i + 1] == 'G' && array1[i + j + 2] == 'A' || array1[j + i] == 'T' && array1[j + i + 1] == 'A' && array1[i + j + 2] == 'A' || array1[j + i] == 'T' && array1[j + i + 1] == 'A' && array1[i + j + 2] == 'G')
                        {
                            number++;

                            break;
                        }
                    }
                }
                if (number == which_gene)
                    break;
            }
            char[] temp2 = new char[find_codon_number(temp) * 3];
            for (int i = 0; i < find_codon_number(temp) * 3; i++)
            {
                temp2[i] = temp[i];
            }

            return temp2;
        }
        static int find_codon_number(char[] array)
        {
            int number = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 'A' || array[i] == 'C' || array[i] == 'G' || array[i] == 'T')
                    number++;
            }
            return (number / 3);
        }

    }
}







