using System;

namespace TestNotationPolonaise
{
    class Program
    {
        /// <summary>
        /// saisie d'une réponse d'un caractère parmi 2
        /// </summary>
        /// <param name="message">message à afficher</param>
        /// <param name="carac1">premier caractère possible</param>
        /// <param name="carac2">second caractère possible</param>
        /// <returns>caractère saisi</returns>
        static char saisie(string message, char carac1, char carac2)
        {
            char reponse;
            do
            {
                Console.WriteLine();
                Console.Write(message + " (" + carac1 + "/" + carac2 + ") ");
                reponse = Console.ReadKey().KeyChar;
            } while (reponse != carac1 && reponse != carac2);
            return reponse;
        }
        /// <summary>
        /// calcul à partir d'une notation polonaise
        /// </summary>
        /// <param name="formule"></param>
        /// <returns></returns>
        static float Polonaise(String formule)
        {
            // transformation formule en vecteur 
            string[] vec = formule.Split(' ');
            // nombre de case du vecteur
            int nbCases = vec.Length;
            while (nbCases > 1)
            {
                // recherche d'un signe
                int k = nbCases - 1;
                while (k > 0 && vec[k] != "+" && vec[k] != "-" && vec[k] != "*" && vec[k] != "/")
                {
                    k--;
                }
                // recuperation des deux valeurs numériques
                float val1 = float.Parse(vec[k + 1]);
                float val2 = float.Parse(vec[k + 2]);
                // calcul
                float result = 0;
                switch (vec[k])
                {
                    case "+": result = val1 + val2; break;
                    case "-": result = val1 - val2; break;
                    case "*": result = val1 * val2; break;
                    case "/": result = val1 / val2; break;
                }
                // stockage du resultat
                vec[k] = result.ToString();
                // décalage de 2 valeurs
                for (int j = k + 1; j < nbCases - 2; j++)
                {
                    vec[j] = vec[j + 2];
                }
                nbCases -= 2;
            }
            return float.Parse(vec[0]);
        }
            /// <summary>
            /// Saisie de formules en notation polonaise pour tester la fonction de calcul
            /// </summary>
            /// <param name="args"></param>
            static void Main(string[] args)
        {
            char reponse;
            // boucle sur la saisie de formules
            do
            {
                Console.WriteLine();
                Console.WriteLine("entrez une formule polonaise en séparant chaque partie par un espace = ");
                String laFormule = Console.ReadLine();
                // affichage du résultat
                Console.WriteLine("Résultat =  " + Polonaise(laFormule));
                // continuer ?
                reponse = saisie("Voulez-vous continuer ?", 'O', 'N');
            } while (reponse == 'O');
        }
    }
}
