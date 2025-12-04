using System.Data.SqlClient;
using System.Data; 
using BO;

namespace DAL
{
    public class ContenirDAO
    {
        private static ContenirDAO unContenirDAO;

        public static ContenirDAO GetContenirDAO()
        {
            if (unContenirDAO == null)
                unContenirDAO = new ContenirDAO();
            return unContenirDAO;
        }

        public int AjouterContenir(Contenir c, SqlConnection cnx = null, SqlTransaction transaction = null)
        {
            bool closeConnexion = false;
            if (cnx == null)
            {
                cnx = ConnexionBD.GetConnexionBD().GetSqlConnexion();
                if (cnx.State == ConnectionState.Closed) cnx.Open();
                closeConnexion = true;
            }

            using (SqlCommand cmd = new SqlCommand(
                @"INSERT INTO CONTENIR (id_produit, id_devis, quantite_commandee, remise_par_ligne)
          VALUES (@idProduit, @idDevis, @qte, @remise)", cnx, transaction))
            {
                cmd.Parameters.AddWithValue("@idProduit", c.ProduitBO.Code);
                cmd.Parameters.AddWithValue("@idDevis", c.Devis.IdDevis);
                cmd.Parameters.AddWithValue("@qte", c.Quantite_commandee);
                cmd.Parameters.AddWithValue("@remise", c.Remise_par_ligne);

                int result = cmd.ExecuteNonQuery();

                if (closeConnexion) cnx.Close();

                return result;
            }
        }

        public int ModifierContenir(Contenir c)
        {
            string req = @"UPDATE contenir 
                           SET quantite_commandee = @qte,
                               remise_par_ligne = @remise
                           WHERE id_produit = @idProduit 
                             AND id_devis = @idDevis";

            using (SqlConnection cnx = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            using (SqlCommand cmd = new SqlCommand(req, cnx))
            {
                if (cnx.State == ConnectionState.Closed) cnx.Open();

                cmd.Parameters.AddWithValue("@idProduit", c.ProduitBO.Code);
                cmd.Parameters.AddWithValue("@idDevis", c.Devis.IdDevis);
                cmd.Parameters.AddWithValue("@qte", c.Quantite_commandee);
                cmd.Parameters.AddWithValue("@remise", c.Remise_par_ligne);

                return cmd.ExecuteNonQuery();
            }
        }

        public int SupprimerContenir(int idProduit, int idDevis)
        {
            string req = @"DELETE FROM contenir 
                           WHERE id_produit = @idProduit AND id_devis = @idDevis";

            using (SqlConnection cnx = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            using (SqlCommand cmd = new SqlCommand(req, cnx))
            {
                if (cnx.State == ConnectionState.Closed) cnx.Open();

                cmd.Parameters.AddWithValue("@idProduit", idProduit);
                cmd.Parameters.AddWithValue("@idDevis", idDevis);

                return cmd.ExecuteNonQuery();
            }
        }
    }
}