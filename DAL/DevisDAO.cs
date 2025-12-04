using BO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DevisDAO
    {
        private static DevisDAO unDevisDAO;

        public static DevisDAO GetDevisDAO()
        {
            if (unDevisDAO == null)
                unDevisDAO = new DevisDAO();
            return unDevisDAO;
        }

        public static List<Devis> GetDevis()
        {
            List<Devis> lesDevis = new List<Devis>();

            using (SqlConnection maConnexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                SqlCommand cmd = new SqlCommand("SELECT id_devis, date_devis, TVA_devis, taux_remise_global_devis, montant_HT_devis, " + 
                    "client.id_client, nom_client, num_fax_client, mail_client, num_phone_client, " + 
                    "code_postal_facture, ville_facture, num_rue_facture, nom_rue_facture, " + 
                    "code_postal_livraison, ville_livraison, num_rue_livraison, nom_rue_livraison, " +  
                    "nom_statut, statut.id_statut " + 
                    "FROM devis " + 
                    " JOIN client on devis.id_client = client.id_client " + 
                    " JOIN statut on devis.id_statut = statut.id_statut", maConnexion);
                SqlDataReader monReader = cmd.ExecuteReader();

                while (monReader.Read())
                {
                    // Client
                    int id_client = (int)monReader["id_client"];
                    string nom_client = monReader["nom_client"].ToString();
                    string num_fax = monReader["num_fax_client"].ToString();
                    string mail = monReader["mail_client"].ToString();
                    string num_phone = monReader["num_phone_client"].ToString();
                    string code_postal_facture = monReader["code_postal_facture"].ToString();
                    string ville_facture = monReader["ville_facture"].ToString();
                    int num_rue_facture = (int)monReader["num_rue_facture"];
                    string nom_rue_facture = monReader["nom_rue_facture"].ToString();
                    string code_postal_livraison = monReader["code_postal_livraison"].ToString();
                    string ville_livraison = monReader["ville_livraison"].ToString();
                    int num_rue_livraison = (int)monReader["num_rue_livraison"];
                    string nom_rue_livraison = monReader["nom_rue_livraison"].ToString();
                    // Objet Client
                    Client unClient = new Client(id_client, nom_client, num_fax, mail, num_phone, code_postal_facture, ville_facture, num_rue_facture, nom_rue_facture,
                    code_postal_livraison, ville_livraison, num_rue_livraison, nom_rue_livraison);
                    // Statut
                    string nom_statut = monReader["nom_statut"].ToString();
                    int id_statut = (int)monReader["id_statut"];
                    // Objet Statut
                    Statut unStatut = new Statut(id_statut, nom_statut);
                    // Devis
                    int id_devis = (int)monReader["id_devis"];
                    DateTime date_devis = (DateTime)monReader["date_devis"];
                    // 1. Lire la valeur en 'double' C# (car 'float' SQL Server correspond à 'double' C#)
                    double tva_double = monReader.GetDouble(monReader.GetOrdinal("TVA_devis"));

                    // 2. Convertir ensuite cette valeur en 'float' pour votre variable
                    // TVA_devis
                    float tva_devis = (float)monReader.GetDouble(monReader.GetOrdinal("TVA_devis"));

                    // taux_remise_global_devis
                    float taux_remise_global_devis = (float)monReader.GetDouble(monReader.GetOrdinal("taux_remise_global_devis"));

                    // montant_HT_devis
                    float montant_devis = (float)monReader.GetDouble(monReader.GetOrdinal("montant_HT_devis"));
                    // Objet Devis
                    Devis unDevis = new Devis(id_devis, date_devis, tva_devis, taux_remise_global_devis, montant_devis , unClient, unStatut);
                    lesDevis.Add(unDevis);
                }
                monReader.Close();
            }
            return lesDevis;
        }

        public static List<Contenir> GetLignesDuDevis(int idDevis)
        {
            List<Contenir> lesLignes = new List<Contenir>();

            // On récupère les infos de la ligne + les infos du produit + la catégorie
            string req = @"SELECT c.id_produit, c.quantite_commandee, c.remise_par_ligne, 
                          p.libelle_produit, p.prix_vente_HT_produit, 
                          cat.id_categorie, cat.nom_categorie
                   FROM contenir c
                   JOIN produit p ON c.id_produit = p.id_produit
                   JOIN categorie cat ON p.id_categorie = cat.id_categorie
                   WHERE c.id_devis = @idDevis";

            using (SqlConnection cnx = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                // Ouverture préventive
                if (cnx.State == ConnectionState.Closed) cnx.Open();

                SqlCommand cmd = new SqlCommand(req, cnx);
                cmd.Parameters.AddWithValue("@idDevis", idDevis);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // 1. Reconstitution de l'objet Categorie
                    int idCat = (int)reader["id_categorie"];
                    string nomCat = reader["nom_categorie"].ToString();
                    Categorie uneCat = new Categorie(idCat, nomCat);

                    // 2. Reconstitution de l'objet ProduitBO
                    int idProd = (int)reader["id_produit"];
                    string libelle = reader["libelle_produit"].ToString();
                    // Attention : SQL float -> C# double -> on cast en float pour ton objet
                    float prix = Convert.ToSingle(reader["prix_vente_HT_produit"]);

                    ProduitBO unProduit = new ProduitBO(idProd, libelle, uneCat, prix);

                    // 3. Reconstitution de la ligne (Contenir)
                    int qte = (int)reader["quantite_commandee"];
                    float remise = Convert.ToSingle(reader["remise_par_ligne"]);

                    // On crée un Devis "vide" juste pour satisfaire le constructeur de Contenir
                    // (On a seulement besoin de l'ID ici)
                    Devis leDevis = new Devis();
                    leDevis.IdDevis = idDevis;

                    Contenir uneLigne = new Contenir(unProduit, leDevis, qte, remise);

                    lesLignes.Add(uneLigne);
                }
                reader.Close();
            }
            return lesLignes;
        }

        public static int ModifierDevis(Devis devis)
        {
            string req = @"UPDATE DEVIS SET 
                    date_devis = @dateDevis,
                    TVA_devis = @tvaDevis,
                    taux_remise_global_devis = @tauxRemiseGlobalDevis,
                    montant_HT_devis = @montantHorsTaxeDevis,
                    id_client = @client,
                    id_statut = @statut
                    WHERE id_devis = @id";
            using (SqlConnection cnx = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                cnx.Open();
                using (SqlCommand cmd = new SqlCommand(req, cnx))
                {
                    cmd.Parameters.AddWithValue("@id", devis.IdDevis);
                    cmd.Parameters.AddWithValue("@dateDevis", devis.Date_devis);
                    cmd.Parameters.AddWithValue("@tvaDevis", devis.TVA_devis);
                    cmd.Parameters.AddWithValue("@tauxRemiseGlobalDevis", devis.Taux_remise_global_devis);
                    cmd.Parameters.AddWithValue("@montantHorsTaxeDevis", devis.Montant_HT_devis);
                    cmd.Parameters.AddWithValue("@client", devis.Client.IdClient);
                    cmd.Parameters.AddWithValue("@statut", devis.Statut.IdStatut);
                    
                    return cmd.ExecuteNonQuery(); 
                }
            }
        }

        public static int SupprimerDevis(int idDevis)
        {
            int nbEnr = 0;

            using (SqlConnection maConnexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            using (SqlCommand cmd = maConnexion.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM devis WHERE id_devis = @id";
                cmd.Parameters.AddWithValue("@id", idDevis);

                try
                {
                    nbEnr = cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    // Si contrainte FK en base, on peut remonter une exception plus parlante
                    throw new Exception("Erreur SQL lors de la suppression : " + ex.Message, ex);
                }
            }

            return nbEnr;
        }

        public static int AjouterDevis(Devis devis)
        {
            using (SqlConnection cnx = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                // CORRECTION MAJEURE : On ne réouvre pas si c'est déjà ouvert
                if (cnx.State == ConnectionState.Closed) cnx.Open();

                SqlTransaction transaction = cnx.BeginTransaction();

                try
                {
                    string reqDevis = @"INSERT INTO DEVIS (date_devis, TVA_devis, taux_remise_global_devis, montant_HT_devis, id_client, id_statut)
                                        VALUES (@date, @tva, @remise, @montant, @idClient, @idStatut);
                                        SELECT SCOPE_IDENTITY();";

                    SqlCommand cmd = new SqlCommand(reqDevis, cnx, transaction);
                    cmd.Parameters.AddWithValue("@date", devis.Date_devis);
                    cmd.Parameters.AddWithValue("@tva", devis.TVA_devis);
                    cmd.Parameters.AddWithValue("@remise", devis.Taux_remise_global_devis);
                    cmd.Parameters.AddWithValue("@montant", devis.Montant_HT_devis);
                    cmd.Parameters.AddWithValue("@idClient", devis.Client.IdClient);
                    cmd.Parameters.AddWithValue("@idStatut", devis.Statut.IdStatut);

                    int idDevisGenere = Convert.ToInt32(cmd.ExecuteScalar());
                    devis.IdDevis = idDevisGenere;

                    foreach (Contenir ligne in devis.Lignes)
                    {
                        ligne.Devis = devis;
                        ContenirDAO.GetContenirDAO().AjouterContenir(ligne, cnx, transaction);
                    }

                    transaction.Commit();
                    return idDevisGenere;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
