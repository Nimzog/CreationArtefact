using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CreationArtefact
{
    /// <summary>
    /// 
    /// </summary>
    public class ClassArtefact
    {
        /// <summary>
        /// 
        /// </summary>
        public string NomArtefact { get; set; } //LE nom de l'objet
        /// <summary>
        /// 
        /// </summary>
        public ClassContenant Contenant { get; set; } //ContenantPrincipale
        /// <summary>
        /// 
        /// </summary>
        public List<ClassFacette> Pouvoirs { get; set; } //Listes des pouvoir de cet artefact.

        int PresenceRestante, PPlvl1, PPlvl2, PPlvl3, PPlvl4, PPlvl5;
        ClassAffinite AffiniteBidon;

        /// <summary>
        /// 
        /// </summary>
        public ClassArtefact()
        {
            //initialization des variables
            Pouvoirs = new List<ClassFacette>();
            Contenant = new ClassContenant();
            NomArtefact = "";
            PresenceRestante = 0;
            PPlvl1 = 0;
            PPlvl2 = 0;
            PPlvl3 = 0;
            PPlvl4 = 0;
            PPlvl5 = 0;
            AffiniteBidon = new ClassAffinite(0);
        }

        /// <summary>
        /// Assigne le cont au Contenant et Contenant.PresenceTotal a PresenceRestante
        /// </summary>
        /// <param name="cont"></param>
        public void SetContenant(ClassContenant cont)
        {
            Contenant = cont;
            PresenceRestante = Contenant.PresenceTotal;
        }

        /// <summary>
        /// Comparer la ClassFacette par TypeFacette et par SubTypeFacette en ordre croissant
        /// </summary>
        /// <param name="facette1"></param>
        /// <param name="facette2"></param>
        /// <returns></returns>
        public int ComparerPouvoir(ClassFacette facette1, ClassFacette facette2)
        {
            int result = 0;

            if (facette1.TypePouvoir == facette2.TypePouvoir)
            {
                if (facette1.TypePouvoir == TypeFacette.FacetteCombat)
                {
                    if (facette1.SubType == facette2.SubType)
                    {
                        result = 0;
                    }
                    else if (facette1.SubType > facette2.SubType)
                    {
                        result = 1;
                    }
                    else
                    {
                        result = -1;
                    }
                }
                else
                {
                    result = 0;
                }
            }
            else if (facette1.TypePouvoir > facette2.TypePouvoir)
            {
                result = 1;
            }
            else
            {
                result = -1;
            }

            return result;
        }

        /// <summary>
        /// Ajoute le pouvoir a la liste Pouvoirs. Ajuste le cout en PP si il existe déjà un pouvoir de cette facette.
        /// </summary>
        /// <param name="pouvoir">Le pouvoir à ajouter</param>
        /// <returns>Si l'ajout a été fait avec succès</returns>
        public bool AddPouvoir(ClassFacette pouvoir)
        {
            bool canAdd = true;

            //calculer les coûts du pouvoir à ajouter
            pouvoir.GenererCoutPouvoir();

            //vérifie s'il y a déjà un(des) pouvoir du même type
            foreach (ClassFacette tPouvoir in Pouvoirs)
            {
                if (tPouvoir.TypePouvoir == pouvoir.TypePouvoir)
                {
                    tPouvoir.CoutPouvoir.PP += 10;
                    pouvoir.CoutPouvoir.PP += 10;
                }

            }

            //verifie si l'objet a une affinité avec le pouvoir a ajouté
            switch (pouvoir.TypePouvoir)
            {
                case TypeFacette.FacetteCombat:
                    if (Contenant.AffiniteAttElement.GetAffinite() > 0 && ((ClassFacetteCombat)pouvoir).Element > 0)
                    {
                        UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteAttElement);
                    }
                    else if (Contenant.AffiniteAttSpec.GetAffinite() > 0 && pouvoir.SubType == SubTypeFacette.AttaqueSpeciale)
                    {
                        UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteAttSpec);
                    }
                    else
                    {
                        UpdatePresence(pouvoir.CoutPouvoir);
                    }
                    break;
                case TypeFacette.FacetteProtection:
                    if (Contenant.AffiniteImmunite.GetAffinite() > 0 && ((ClassFacetteProtection)pouvoir).Immunite > 0)
                    {
                        UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteImmunite);
                    }
                    else if (Contenant.AffiniteImmuniteMystique.GetAffinite() > 0 && ((ClassFacetteProtection)pouvoir).ImmuniteMagique > 0)
                    {
                        UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteImmuniteMystique);
                    }
                    else if (Contenant.AffiniteImmunitePsy.GetAffinite() > 0 && ((ClassFacetteProtection)pouvoir).ImmunitePsychique > 0)
                    {
                        UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteImmunitePsy);
                    }
                    else if (Contenant.AffiniteImmuniteElem.GetAffinite() > 0 && ((ClassFacetteProtection)pouvoir).ImmuniteElementaire > 0)
                    {
                        UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteImmuniteElem);
                    }
                    else if (Contenant.AffiniteSeuilInvul.GetAffinite() > 0 && ((ClassFacetteProtection)pouvoir).SeuilInvul > 0)
                    {
                        UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteSeuilInvul);
                    }
                    else if (Contenant.AffiniteAmelorationRes.GetAffinite() > 0 && ((ClassFacetteProtection)pouvoir).AugmentRes > 0)
                    {
                        UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteAmelorationRes);
                    }
                    else
                    {
                        UpdatePresence(pouvoir.CoutPouvoir);
                    }
                    break;
                case TypeFacette.FacetteMagique:
                    if (Contenant.AffiniteAmpliAMR.GetAffinite() > 0 && ((ClassFacetteMagique)pouvoir).AmpliAMR > 0)
                    {
                        UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteAmpliAMR);
                    }
                    else if (Contenant.AffiniteProjMag.GetAffinite() > 0 && ((ClassFacetteMagique)pouvoir).ProjMagique > 0)
                    {
                        UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteProjMag);
                    }
                    else if (Contenant.AffinitePuissAjoutee.GetAffinite() > 0 && ((ClassFacetteMagique)pouvoir).PuissAjout > 0)
                    {
                        UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffinitePuissAjoutee);
                    }
                    else if (Contenant.AffiniteReceptacleZeon.GetAffinite() > 0 && ((ClassFacetteMagique)pouvoir).ReceptZeon > 0)
                    {
                        UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteReceptacleZeon);
                    }
                    else if (Contenant.AffiniteRechargeMag.GetAffinite() > 0 && ((ClassFacetteMagique)pouvoir).RegenZeon > 0)
                    {
                        UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteRechargeMag);
                    }
                    else if (Contenant.AffiniteTestResAccrus.GetAffinite() > 0 && ((ClassFacetteMagique)pouvoir).TestResMysAcc > 0)
                    {
                        UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteTestResAccrus);
                    }
                    else
                    {
                        UpdatePresence(pouvoir.CoutPouvoir);
                    }
                    break;
                case TypeFacette.FacettePsychique:
                    if (Contenant.AffiniteTalent.GetAffinite() > 0 && ((ClassFacettePsychique)pouvoir).Talent > 0)
                    {
                        UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteTalent);
                    }
                    else if (Contenant.AffiniteTestResAccrus.GetAffinite() > 0 && ((ClassFacettePsychique)pouvoir).TestResPsyAccrus > 0)
                    {
                        UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteTestResAccrus);
                    }
                    else if (Contenant.AffiniteAmelioMaintPouvoir.GetAffinite() > 0 && ((ClassFacettePsychique)pouvoir).MaintPouvoir > 0)
                    {
                        UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteAmelioMaintPouvoir);
                    }
                    else
                    {
                        UpdatePresence(pouvoir.CoutPouvoir);
                    }
                    break;
                case TypeFacette.FacetteConvocation:
                    if (Contenant.AffinitePresAccru.GetAffinite() > 0 && ((ClassFacetteConvocation)pouvoir).PresenceAccrue > 0)
                    {
                        UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffinitePresAccru);
                    }
                    else if (Contenant.AffiniteConvoAccrue.GetAffinite() > 0 && ((ClassFacetteConvocation)pouvoir).ConvoAccrue > 0)
                    {
                        UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteConvoAccrue);
                    }
                    else
                    {
                        UpdatePresence(pouvoir.CoutPouvoir);
                    }
                    break;
                case TypeFacette.FacetteInnee:
                    if (Contenant.AffiniteMagieInnee.GetAffinite() > 0)
                    {
                        UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteMagieInnee);
                    }
                    else if (Contenant.AffiniteSortsAuto.GetAffinite() > 0 && ((ClassFacetteMagieInnee)pouvoir).SortAutomatique.Count > 0)
                    {
                        UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteSortsAuto);
                    }
                    else if (Contenant.AffiniteLanceurSort.GetAffinite() > 0 && ((ClassFacetteMagieInnee)pouvoir).LanceurSort.Count > 0)
                    {
                        UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteLanceurSort);
                    }
                    else if (Contenant.AffiniteCompLancement.GetAffinite() > 0 && ((ClassFacetteMagieInnee)pouvoir).CompLancement != 0)
                    {
                        UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteCompLancement);
                    }
                    else
                    {
                        UpdatePresence(pouvoir.CoutPouvoir);
                    }
                    break;
                case TypeFacette.FacetteAugmentation:
                    if (Contenant.AffiniteAugmentDeplacement.GetAffinite() > 0 && ((ClassFacetteAugmentation)pouvoir).AugDeplacement != 0)
                    {
                        UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteAugmentDeplacement);
                    }
                    else if (Contenant.AffiniteAugmentCompSec.GetAffinite() > 0 && ((ClassFacetteAugmentation)pouvoir).AugCompSec != 0)
                    {
                        UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteAugmentCompSec);
                    }
                    else if (Contenant.AffiniteAugmentCharac.GetAffinite() > 0 && ((ClassFacetteAugmentation)pouvoir).AugCarac != 0)
                    {
                        UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteAugmentCharac);
                    }
                    else if (Contenant.AffiniteSubstiCarac.GetAffinite() > 0 && ((ClassFacetteAugmentation)pouvoir).SubstiCarac != 0)
                    {
                        UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteSubstiCarac);
                    }
                    else
                    {
                        UpdatePresence(pouvoir.CoutPouvoir);
                    }
                    break;
                case TypeFacette.FacetteMaitrise:
                    if (Contenant.AffiniteReserveKi.GetAffinite() > 0 && ((ClassFacetteMaitrise)pouvoir).ReserveKi != 0)
                    {
                        UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteReserveKi);
                    }
                    else
                    {
                        UpdatePresence(pouvoir.CoutPouvoir);
                    }
                    break;
                case TypeFacette.FacetteEsoterique:
                    if (Contenant.AffiniteAltDestin.GetAffinite() > 0 && ((ClassFacetteEsoterique)pouvoir).AlterationDestion != 0)
                    {
                        UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteAltDestin);
                    }
                    else if (Contenant.AffiniteVision.GetAffinite() > 0 && ((ClassFacetteEsoterique)pouvoir).Vision != 0)
                    {
                        UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteVision);
                    }
                    else if (Contenant.AffiniteCreatePortail.GetAffinite() > 0 && ((ClassFacetteEsoterique)pouvoir).Portal != 0)
                    {
                        UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteCreatePortail);
                    }
                    else if (Contenant.AffiniteEffetMystique.GetAffinite() > 0 && pouvoir.SubType == SubTypeFacette.EffetMystique)
                    {
                        UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteEffetMystique);
                    }
                    else
                    {
                        UpdatePresence(pouvoir.CoutPouvoir);
                    }
                    break;
                default:
                    UpdatePresence(pouvoir.CoutPouvoir);
                    break;
            }
            Pouvoirs.Add(pouvoir);
            Pouvoirs.Sort(ComparerPouvoir);

            return canAdd;
        }

        /// <summary>
        /// Ajoute le pouvoir a la liste Pouvoirs. Ajuste le cout en PP si il existe déjà un pouvoir de cette facette.
        /// </summary>
        /// <param name="pouvoir">Le pouvoir à ajouter</param>
        /// /// <param name="pouvoir">Le pouvoir à ajouter</param>
        /// <returns>Si l'ajout a été fait avec succès</returns>
        public bool AddPouvoir(ClassFacetteEsoterique pouvoir, bool flag)
        {
            bool canAdd = true;

            //calculer les coûts du pouvoir à ajouter
            pouvoir.GenererCoutPouvoir(this);

            //vérifie s'il y a déjà un(des) pouvoir du même type
            foreach (ClassFacette tPouvoir in Pouvoirs)
            {
                if (tPouvoir.TypePouvoir == pouvoir.TypePouvoir)
                {
                    tPouvoir.CoutPouvoir.PP += 10;
                    pouvoir.CoutPouvoir.PP += 10;
                }

            }

            canAdd = UpdatePresence(pouvoir.CoutPouvoir);

            //
            if (canAdd)
            {
                Pouvoirs.Add(pouvoir);
                Pouvoirs.Sort(ComparerPouvoir);
            }

            return canAdd;
        }

        /// <summary>
        /// Remplace le pouvoir a l'index par le pouvoir passé en parametre
        /// </summary>
        /// <param name="pouvoir"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool UpdatePouvoir(ClassFacette pouvoir, int index)
        {
            bool canAdd = false;
            int affiniteCurrent, extraAffinite, suppose, current, nouveau;

            pouvoir.GenererCoutPouvoir();            

            affiniteCurrent = 0;
            extraAffinite = 0;
            current = Pouvoirs[index].CoutPouvoir.Presence;
            nouveau = pouvoir.CoutPouvoir.GeneratePresence();
            suppose = Pouvoirs[index].CoutPouvoir.GeneratePresence();

            //si le niveau de l'original est différent du nouveau
            if (current != nouveau)
            {
                //vérifie si le cout du pouvoir original était réduit
                if (current != suppose)
                {
                    affiniteCurrent = suppose - current;
                    //vérifie si le nouveau cout est plus élevé que l'affinité
                    if (affiniteCurrent > nouveau)
                    {
                        extraAffinite = affiniteCurrent - nouveau;
                        //réassigne la différence
                        switch (pouvoir.TypePouvoir)
                        {
                            case TypeFacette.FacetteCombat:
                                if (((ClassFacetteCombat)pouvoir).Element > 0)
                                {
                                    Contenant.AffiniteAttElement.IncremeteAffinite(extraAffinite);
                                }
                                else if (pouvoir.SubType == SubTypeFacette.AttaqueSpeciale)
                                {
                                    Contenant.AffiniteAttSpec.IncremeteAffinite(extraAffinite);
                                }
                                break;
                            case TypeFacette.FacetteProtection:
                                if (((ClassFacetteProtection)pouvoir).Immunite > 0)
                                {
                                    Contenant.AffiniteImmunite.IncremeteAffinite(extraAffinite);
                                }
                                else if (((ClassFacetteProtection)pouvoir).ImmuniteMagique > 0)
                                {
                                    Contenant.AffiniteImmuniteMystique.IncremeteAffinite(extraAffinite);
                                }
                                else if (((ClassFacetteProtection)pouvoir).ImmunitePsychique > 0)
                                {
                                    Contenant.AffiniteImmunitePsy.IncremeteAffinite(extraAffinite);
                                }
                                else if (((ClassFacetteProtection)pouvoir).ImmuniteElementaire > 0)
                                {
                                    Contenant.AffiniteImmuniteElem.IncremeteAffinite(extraAffinite);
                                }
                                else if (((ClassFacetteProtection)pouvoir).SeuilInvul > 0)
                                {
                                    Contenant.AffiniteSeuilInvul.IncremeteAffinite(extraAffinite);
                                }
                                else if (((ClassFacetteProtection)pouvoir).AugmentRes > 0)
                                {
                                    Contenant.AffiniteAmelorationRes.IncremeteAffinite(extraAffinite);
                                }
                                break;
                            case TypeFacette.FacetteMagique:
                                if (((ClassFacetteMagique)pouvoir).AmpliAMR > 0)
                                {
                                    Contenant.AffiniteAmpliAMR.IncremeteAffinite(extraAffinite);
                                }
                                else if (((ClassFacetteMagique)pouvoir).ProjMagique > 0)
                                {
                                    Contenant.AffiniteProjMag.IncremeteAffinite(extraAffinite);
                                }
                                else if (((ClassFacetteMagique)pouvoir).PuissAjout > 0)
                                {
                                    Contenant.AffinitePuissAjoutee.IncremeteAffinite(extraAffinite);
                                }
                                else if (((ClassFacetteMagique)pouvoir).ReceptZeon > 0)
                                {
                                    Contenant.AffiniteReceptacleZeon.IncremeteAffinite(extraAffinite);
                                }
                                else if (((ClassFacetteMagique)pouvoir).RegenZeon > 0)
                                {
                                    Contenant.AffiniteRechargeMag.IncremeteAffinite(extraAffinite);
                                }
                                else if (((ClassFacetteMagique)pouvoir).TestResMysAcc > 0)
                                {
                                    Contenant.AffiniteTestResAccrus.IncremeteAffinite(extraAffinite);
                                }
                                break;
                            case TypeFacette.FacettePsychique:
                                if (((ClassFacettePsychique)pouvoir).Talent > 0)
                                {
                                    Contenant.AffiniteTalent.IncremeteAffinite(extraAffinite);
                                }
                                else if (((ClassFacettePsychique)pouvoir).TestResPsyAccrus > 0)
                                {
                                    Contenant.AffiniteTestResAccrus.IncremeteAffinite(extraAffinite);
                                }
                                else if (((ClassFacettePsychique)pouvoir).MaintPouvoir > 0)
                                {
                                    Contenant.AffiniteAmelioMaintPouvoir.IncremeteAffinite(extraAffinite);
                                }
                                break;
                            case TypeFacette.FacetteConvocation:
                                if (((ClassFacetteConvocation)pouvoir).PresenceAccrue > 0)
                                {
                                    Contenant.AffinitePresAccru.IncremeteAffinite(extraAffinite);
                                }
                                else if (((ClassFacetteConvocation)pouvoir).ConvoAccrue > 0)
                                {
                                    Contenant.AffiniteConvoAccrue.IncremeteAffinite(extraAffinite);
                                }
                                break;
                            case TypeFacette.FacetteInnee:
                                if (Contenant.AffiniteMagieInnee.HasAffinite())
                                {
                                    Contenant.AffiniteMagieInnee.IncremeteAffinite(extraAffinite);
                                }
                                else if (((ClassFacetteMagieInnee)pouvoir).SortAutomatique.Count > 0)
                                {
                                    Contenant.AffiniteSortsAuto.IncremeteAffinite(extraAffinite);
                                }
                                else if (((ClassFacetteMagieInnee)pouvoir).LanceurSort.Count > 0)
                                {
                                    Contenant.AffiniteLanceurSort.IncremeteAffinite(extraAffinite);
                                }
                                else if (((ClassFacetteMagieInnee)pouvoir).CompLancement != 0)
                                {
                                    Contenant.AffiniteCompLancement.IncremeteAffinite(extraAffinite);
                                }

                                break;
                            case TypeFacette.FacetteAugmentation:
                                if (((ClassFacetteAugmentation)pouvoir).AugDeplacement != 0)
                                {
                                    Contenant.AffiniteAugmentDeplacement.IncremeteAffinite(extraAffinite);
                                }
                                else if (((ClassFacetteAugmentation)pouvoir).AugCompSec != 0)
                                {
                                    Contenant.AffiniteAugmentCompSec.IncremeteAffinite(extraAffinite);
                                }
                                else if (((ClassFacetteAugmentation)pouvoir).AugCarac != 0)
                                {
                                    Contenant.AffiniteAugmentCharac.IncremeteAffinite(extraAffinite);
                                }
                                else if (((ClassFacetteAugmentation)pouvoir).SubstiCarac != 0)
                                {
                                    Contenant.AffiniteSubstiCarac.IncremeteAffinite(extraAffinite);
                                }
                                break;
                            case TypeFacette.FacetteMaitrise:
                                if (((ClassFacetteMaitrise)pouvoir).ReserveKi != 0)
                                {
                                    Contenant.AffiniteReserveKi.IncremeteAffinite(extraAffinite);
                                }
                                break;
                            case TypeFacette.FacetteEsoterique:
                                if (((ClassFacetteEsoterique)pouvoir).AlterationDestion != 0)
                                {
                                    Contenant.AffiniteAltDestin.IncremeteAffinite(extraAffinite);
                                }
                                else if (((ClassFacetteEsoterique)pouvoir).Vision != 0)
                                {
                                    Contenant.AffiniteVision.IncremeteAffinite(extraAffinite);
                                }
                                else if (((ClassFacetteEsoterique)pouvoir).Portal != 0)
                                {
                                    Contenant.AffiniteCreatePortail.IncremeteAffinite(extraAffinite);
                                }
                                else if (pouvoir.SubType == SubTypeFacette.EffetMystique)
                                {
                                    Contenant.AffiniteEffetMystique.IncremeteAffinite(extraAffinite);
                                }
                                break;
                            default:

                                break;
                        }
                        affiniteCurrent -= extraAffinite;
                    }
                    nouveau -= affiniteCurrent;
                }
                pouvoir.CoutPouvoir.Presence = nouveau;
            }

            Pouvoirs[index] = pouvoir;
            MAJPpointPouvoirPresence();

            return canAdd;
        }

        /// <summary>
        /// Met a jour la presence du pouvoir.
        /// </summary>
        /// <param name="coutPouvoir"></param>
        /// <param name="affinite"></param>
        /// <returns></returns>
        private bool UpdatePresence(ClassCoutPouvoir coutPouvoir, ClassAffinite affinite)
        {
            bool canAdd = true;
            int tempAff = affinite.GetAffinite();

            //verifie s'il y a assé de présence restante dans l'objet
            switch (coutPouvoir.Niveau)
            {
                case 1:
                    if (tempAff <= 10 && tempAff > 0)
                    {
                        coutPouvoir.Presence = (10 - tempAff);
                        affinite.UpdateAffinite(tempAff);
                    }
                    else if (tempAff == 0)
                    {
                        coutPouvoir.Presence = 10;
                    }
                    else if (tempAff > 10)
                    {
                        affinite.UpdateAffinite(10);
                        coutPouvoir.Presence = 0;
                    }
                    break;
                case 2:
                    if (tempAff <= 15 && tempAff > 0)
                    {
                        coutPouvoir.Presence = (15 - tempAff);
                        affinite.UpdateAffinite(tempAff);
                    }
                    else if (tempAff == 0)
                    {
                        coutPouvoir.Presence = 15;
                    }
                    else if (tempAff > 15)
                    {
                        affinite.UpdateAffinite(15);
                        coutPouvoir.Presence = 0;
                    }
                    break;
                case 3:
                    if (tempAff <= 20 && tempAff > 0)
                    {
                        coutPouvoir.Presence = (25 - tempAff);
                        affinite.UpdateAffinite(tempAff);
                    }
                    else if (tempAff == 0)
                    {
                        coutPouvoir.Presence = 25;
                    }
                    break;
                case 4:
                    if (PresenceRestante - (60 - tempAff) >= 0)
                    {
                        if (tempAff <= 20 && tempAff > 0)
                        {
                            coutPouvoir.Presence = (60 - tempAff);
                            affinite.UpdateAffinite(tempAff);
                        }
                        else if (tempAff == 0)
                        {
                            coutPouvoir.Presence = 60;
                        }
                    }
                    break;
                case 5:
                    if (tempAff <= 20 && tempAff > 0)
                    {
                        coutPouvoir.Presence = (100 - tempAff);
                        affinite.UpdateAffinite(tempAff);
                    }
                    else if (tempAff == 0)
                    {
                        coutPouvoir.Presence = 100;
                    }
                    break;
                default:
                    coutPouvoir.Presence = -1;
                    break;
            }

            return canAdd;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="coutPouvoir"></param>
        /// <returns></returns>
        private bool UpdatePresence(ClassCoutPouvoir coutPouvoir)
        {
            bool canAdd = false;

            //verifie s'il y a assé de présence restante dans l'objet
            switch (coutPouvoir.Niveau)
            {
                case 1:
                    coutPouvoir.Presence = 10;
                    break;
                case 2:
                    coutPouvoir.Presence = 15;
                    break;
                case 3:
                    coutPouvoir.Presence = 25;
                    break;
                case 4:
                    coutPouvoir.Presence = 60;
                    break;
                case 5:
                    coutPouvoir.Presence = 100;
                    break;
                default:
                    coutPouvoir.Presence = -1;
                    break;
            }

            return canAdd;
        }

        /// <summary>
        /// Recalcule les PPs et la présence de l'artéfact
        /// </summary>
        public void MAJPpointPouvoirPresence()
        {  
            PPlvl1 = 0; PPlvl2 = 0; PPlvl3 = 0; PPlvl4 = 0; PPlvl5 = 0;
            PresenceRestante = Contenant.PresenceTotal;
            foreach (ClassFacette tPouvoir in Pouvoirs)
            {
                PresenceRestante -= tPouvoir.CoutPouvoir.Presence;
                switch (tPouvoir.CoutPouvoir.Niveau)
                {
                    case 1:
                        PPlvl1 += tPouvoir.CoutPouvoir.PP;
                        break;
                    case 2:
                        PPlvl2 += tPouvoir.CoutPouvoir.PP;
                        break;
                    case 3:
                        PPlvl3 += tPouvoir.CoutPouvoir.PP;
                        break;
                    case 4:
                        PPlvl4 += tPouvoir.CoutPouvoir.PP;
                        break;
                    case 5:
                        PPlvl5 += tPouvoir.CoutPouvoir.PP;
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Recalcule la presence de l'item et des pouvoir et des PP
        /// </summary>
        /// <returns>-1 si tout vas bien sinon l'index ou il y a une erreur</returns>
        public int RecalculePresence()
        {
            int indexPasErreur = -1, index = 0;
            bool itemValide = true;

            //remet la presence et les affinités du contenant aux valeurs "initiales"
            PresenceRestante = Contenant.PresenceTotal;
            Contenant.ResetAffinite();
            Pouvoirs.Sort(ComparerPouvoir);
            foreach (ClassFacette pouvoir in Pouvoirs)
            {
                //calculer les coûts du pouvoir
                pouvoir.GenererCoutPouvoir();

                //vérifie s'il y a déjà un(des) pouvoir du même type
                foreach (ClassFacette tPouvoir in Pouvoirs)
                {
                    if (tPouvoir.TypePouvoir == pouvoir.TypePouvoir)
                    {
                        tPouvoir.CoutPouvoir.PP += 10;
                        pouvoir.CoutPouvoir.PP += 10;
                    }

                }

                //verifie si l'objet a une affinité avec le pouvoir
                switch (pouvoir.TypePouvoir)
                {
                    case TypeFacette.FacetteCombat:
                        if (Contenant.AffiniteAttElement.GetAffinite() > 0 && ((ClassFacetteCombat)pouvoir).Element > 0)
                        {
                            itemValide = UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteAttElement);
                        }
                        else if (Contenant.AffiniteAttSpec.GetAffinite() > 0 && pouvoir.SubType == SubTypeFacette.AttaqueSpeciale)
                        {
                            itemValide = UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteAttSpec);
                        }
                        else
                        {
                            itemValide = UpdatePresence(pouvoir.CoutPouvoir);
                        }
                        break;
                    case TypeFacette.FacetteProtection:
                        if (Contenant.AffiniteImmunite.GetAffinite() > 0 && ((ClassFacetteProtection)pouvoir).Immunite > 0)
                        {
                            itemValide = UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteImmunite);
                        }
                        else if (Contenant.AffiniteImmuniteMystique.GetAffinite() > 0 && ((ClassFacetteProtection)pouvoir).ImmuniteMagique > 0)
                        {
                            itemValide = UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteImmuniteMystique);
                        }
                        else if (Contenant.AffiniteImmunitePsy.GetAffinite() > 0 && ((ClassFacetteProtection)pouvoir).ImmunitePsychique > 0)
                        {
                            itemValide = UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteImmunitePsy);
                        }
                        else if (Contenant.AffiniteImmuniteElem.GetAffinite() > 0 && ((ClassFacetteProtection)pouvoir).ImmuniteElementaire > 0)
                        {
                            itemValide = UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteImmuniteElem);
                        }
                        else if (Contenant.AffiniteSeuilInvul.GetAffinite() > 0 && ((ClassFacetteProtection)pouvoir).SeuilInvul > 0)
                        {
                            itemValide = UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteSeuilInvul);
                        }
                        else if (Contenant.AffiniteAmelorationRes.GetAffinite() > 0 && ((ClassFacetteProtection)pouvoir).AugmentRes > 0)
                        {
                            itemValide = UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteAmelorationRes);
                        }
                        else
                        {
                            itemValide = UpdatePresence(pouvoir.CoutPouvoir);
                        }
                        break;
                    case TypeFacette.FacetteMagique:
                        if (Contenant.AffiniteAmpliAMR.GetAffinite() > 0 && ((ClassFacetteMagique)pouvoir).AmpliAMR > 0)
                        {
                            itemValide = UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteAmpliAMR);
                        }
                        else if (Contenant.AffiniteProjMag.GetAffinite() > 0 && ((ClassFacetteMagique)pouvoir).ProjMagique > 0)
                        {
                            itemValide = UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteProjMag);
                        }
                        else if (Contenant.AffinitePuissAjoutee.GetAffinite() > 0 && ((ClassFacetteMagique)pouvoir).PuissAjout > 0)
                        {
                            itemValide = UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffinitePuissAjoutee);
                        }
                        else if (Contenant.AffiniteReceptacleZeon.GetAffinite() > 0 && ((ClassFacetteMagique)pouvoir).ReceptZeon > 0)
                        {
                            itemValide = UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteReceptacleZeon);
                        }
                        else if (Contenant.AffiniteRechargeMag.GetAffinite() > 0 && ((ClassFacetteMagique)pouvoir).RegenZeon > 0)
                        {
                            itemValide = UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteRechargeMag);
                        }
                        else if (Contenant.AffiniteTestResAccrus.GetAffinite() > 0 && ((ClassFacetteMagique)pouvoir).TestResMysAcc > 0)
                        {
                            itemValide = UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteTestResAccrus);
                        }
                        else
                        {
                            itemValide = UpdatePresence(pouvoir.CoutPouvoir);
                        }
                        break;
                    case TypeFacette.FacettePsychique:
                        if (Contenant.AffiniteTalent.GetAffinite() > 0 && ((ClassFacettePsychique)pouvoir).Talent > 0)
                        {
                            itemValide = UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteTalent);
                        }
                        else if (Contenant.AffiniteTestResAccrus.GetAffinite() > 0 && ((ClassFacettePsychique)pouvoir).TestResPsyAccrus > 0)
                        {
                            itemValide = UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteTestResAccrus);
                        }
                        else if (Contenant.AffiniteAmelioMaintPouvoir.GetAffinite() > 0 && ((ClassFacettePsychique)pouvoir).MaintPouvoir > 0)
                        {
                            itemValide = UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteAmelioMaintPouvoir);
                        }
                        else
                        {
                            itemValide = UpdatePresence(pouvoir.CoutPouvoir);
                        }
                        break;
                    case TypeFacette.FacetteConvocation:
                        if (Contenant.AffinitePresAccru.GetAffinite() > 0 && ((ClassFacetteConvocation)pouvoir).PresenceAccrue > 0)
                        {
                            itemValide = UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffinitePresAccru);
                        }
                        else if (Contenant.AffiniteConvoAccrue.GetAffinite() > 0 && ((ClassFacetteConvocation)pouvoir).ConvoAccrue > 0)
                        {
                            itemValide = UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteConvoAccrue);
                        }
                        else
                        {
                            itemValide = UpdatePresence(pouvoir.CoutPouvoir);
                        }
                        break;
                    case TypeFacette.FacetteInnee:
                        if (Contenant.AffiniteMagieInnee.GetAffinite() > 0)
                        {
                            itemValide = UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteMagieInnee);
                        }
                        else if (Contenant.AffiniteSortsAuto.GetAffinite() > 0 && ((ClassFacetteMagieInnee)pouvoir).SortAutomatique.Count > 0)
                        {
                            itemValide = UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteSortsAuto);
                        }
                        else if (Contenant.AffiniteLanceurSort.GetAffinite() > 0 && ((ClassFacetteMagieInnee)pouvoir).LanceurSort.Count > 0)
                        {
                            itemValide = UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteLanceurSort);
                        }
                        else if (Contenant.AffiniteCompLancement.GetAffinite() > 0 && ((ClassFacetteMagieInnee)pouvoir).CompLancement != 0)
                        {
                            itemValide = UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteCompLancement);
                        }
                        else
                        {
                            itemValide = UpdatePresence(pouvoir.CoutPouvoir);
                        }
                        break;
                    case TypeFacette.FacetteAugmentation:
                        if (Contenant.AffiniteAugmentDeplacement.GetAffinite() > 0 && ((ClassFacetteAugmentation)pouvoir).AugDeplacement != 0)
                        {
                            itemValide = UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteAugmentDeplacement);
                        }
                        else if (Contenant.AffiniteAugmentCompSec.GetAffinite() > 0 && ((ClassFacetteAugmentation)pouvoir).AugCompSec != 0)
                        {
                            itemValide = UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteAugmentCompSec);
                        }
                        else if (Contenant.AffiniteAugmentCharac.GetAffinite() > 0 && ((ClassFacetteAugmentation)pouvoir).AugCarac != 0)
                        {
                            itemValide = UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteAugmentCharac);
                        }
                        else if (Contenant.AffiniteSubstiCarac.GetAffinite() > 0 && ((ClassFacetteAugmentation)pouvoir).SubstiCarac != 0)
                        {
                            itemValide = UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteSubstiCarac);
                        }
                        else
                        {
                            itemValide = UpdatePresence(pouvoir.CoutPouvoir);
                        }
                        break;
                    case TypeFacette.FacetteMaitrise:
                        if (Contenant.AffiniteReserveKi.GetAffinite() > 0 && ((ClassFacetteMaitrise)pouvoir).ReserveKi != 0)
                        {
                            itemValide = UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteReserveKi);
                        }
                        else
                        {
                            itemValide = UpdatePresence(pouvoir.CoutPouvoir);
                        }
                        break;
                    case TypeFacette.FacetteEsoterique:
                        if (Contenant.AffiniteAltDestin.GetAffinite() > 0 && ((ClassFacetteEsoterique)pouvoir).AlterationDestion != 0)
                        {
                            itemValide = UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteAltDestin);
                        }
                        else if (Contenant.AffiniteVision.GetAffinite() > 0 && ((ClassFacetteEsoterique)pouvoir).Vision != 0)
                        {
                            itemValide = UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteVision);
                        }
                        else if (Contenant.AffiniteCreatePortail.GetAffinite() > 0 && ((ClassFacetteEsoterique)pouvoir).Portal != 0)
                        {
                            itemValide = UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteCreatePortail);
                        }
                        else if (Contenant.AffiniteEffetMystique.GetAffinite() > 0 && pouvoir.SubType == SubTypeFacette.EffetMystique)
                        {
                            itemValide = UpdatePresence(pouvoir.CoutPouvoir, Contenant.AffiniteEffetMystique);
                        }
                        else
                        {
                            itemValide = UpdatePresence(pouvoir.CoutPouvoir);
                        }
                        break;
                    default:
                        itemValide = UpdatePresence(pouvoir.CoutPouvoir);
                        break;
                }
                
                //si l'item est invalide e.g.pas assez de presence
                if (!itemValide)
                {
                    return index;
                }
                index++;
            }

            MAJPpointPouvoirPresence();

            return indexPasErreur;
        }

        public int GetPresence()
        {
            return PresenceRestante;
        }

        /// <summary>
        /// Génère la description de l'artéfact
        /// </summary>
        /// <param name="description">Liste de ligne</param>
        public void DescriptionArtefact(List<string> description)
        {
            Contenant.DescriptionObjet(description);

            if (Pouvoirs.Count > 0)
            {
                description.Add(" ");
                description.Add("Liste de(s) pouvoir(s):");
            }


            TypeFacette typeFacette = TypeFacette.Aucune;

            foreach (ClassFacette pouvoir in Pouvoirs)
            {

                if (typeFacette != pouvoir.TypePouvoir)
                {
                    description.Add("__________________________________");
                    description.Add(" ");
                    switch (pouvoir.TypePouvoir)
                    {
                        case TypeFacette.FacetteQualite:
                            description.Add("Facette générale de qualité:");
                            break;
                        case TypeFacette.FacetteCombat:
                            description.Add("Facette offensive:");
                            break;
                        case TypeFacette.FacetteDefensive:
                            description.Add("Facette défensive:");
                            break;
                        case TypeFacette.FacetteProtection:
                            description.Add("Facette de protection:");
                            break;
                        case TypeFacette.FacetteMagique:
                            description.Add("Facette de renforcement magique:");
                            break;
                        case TypeFacette.FacettePsychique:
                            description.Add("Facette de renforcement psychique:");
                            break;
                        case TypeFacette.FacetteConvocation:
                            description.Add("Facette de renforcement de la convocation:");
                            break;
                        case TypeFacette.FacetteInnee:
                            description.Add("Facette de magie innée:");
                            break;
                        case TypeFacette.FacetteAugmentation:
                            description.Add("Facette d'augmentation:");
                            break;
                        case TypeFacette.FacetteMaitrise:
                            description.Add("Facette de maîtrise:");
                            break;
                        case TypeFacette.FacetteEsoterique:
                            description.Add("Facette ésotérique:");
                            break;
                        default:
                            description.Add("Facette non définie");
                            break;
                    }
                    typeFacette = pouvoir.TypePouvoir;
                }
                else
                {
                    description.Add("---------------------------------------------------------------");
                }

                pouvoir.DescriptionPouvoir(description);
            }
            description.Add("__________________________________");
            description.Add(" ");
            if (Pouvoirs.Count > 0)
            {
                description.Add("PP de niveau 1: " + PPlvl1 + ".");
                description.Add("PP de niveau 2: " + PPlvl2 + ".");
                description.Add("PP de niveau 3: " + PPlvl3 + ". ");
                description.Add("PP de niveau 4: " + PPlvl4 + ".");
                description.Add("PP de niveau 5: " + PPlvl5 + ".");
                description.Add("Présence restante: " + PresenceRestante + ".");
            }

            //return tempDesc;
        }

        /// <summary>
        /// Construit le XML a exporter
        /// </summary>
        /// <param name="writer">Le fichier/stream du XML</param>
        public void ExportXML(XmlWriter writer)
        {
            //StringBuilder tempXML = new StringBuilder();

            writer.WriteProcessingInstruction("xml", "version='1.0'");

            //construit le xml du contenant
            Contenant.ExportXML(writer);

            //construit le xml des pouvoirs
            writer.WriteStartElement("Pouvoirs");
            foreach (ClassFacette pouvoir in Pouvoirs)
            {
                pouvoir.ExportXML(writer);
            }
            writer.WriteEndElement();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ClassAffinite
    {
        int Affinite;
        bool Selected;

        public ClassAffinite()
        {
            Affinite = 0;
            Selected = false;
        }

        public ClassAffinite(int valeur)
        {
            Affinite = valeur;
            Selected = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="affinite"></param>
        public void SetAffinite(int affinite)
        {
            Affinite = affinite;
            Selected = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mod"></param>
        public void UpdateAffinite(int mod)
        {
            Affinite -= mod;
        }

        public void IncremeteAffinite(int inc)
        {
            Affinite += inc;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetAffinite()
        {
            return Affinite;
        }

        public bool HasAffinite()
        {
            return Selected;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ClassContenant
    {
        /// <summary>
        /// quel type de matériel l'objet a été fabriqué
        /// </summary>
        public int Materiel { get; set; }
        /// <summary>
        /// index 0 = mauvaise qualité, 1 = 0, 2 = +5, 3 = +10
        /// </summary>
        public int Qualite { get; set; }
        /// <summary>
        /// Presence de base de l'objet
        /// </summary>
        public int PresenceBase { get; set; }
        /// <summary>
        /// Presence calculé total
        /// </summary>
        public int PresenceTotal { get; set; }
        /// <summary>
        /// anneau, épée, armure de cuir, etc.
        /// </summary>
        public string TypeObjet { get; set; }
        /// <summary>
        /// si l'objet a été fait pour la création d'un artéfact
        /// </summary>
        public bool Exclusif { get; set; }
        #region Liste d'affinité possible
        /// <summary>
        /// 
        /// </summary>
        public ClassAffinite AffiniteSortsAuto;
        /// <summary>
        /// 
        /// </summary>
        public ClassAffinite AffiniteMagieInnee;
        /// <summary>
        /// 
        /// </summary>
        public ClassAffinite AffiniteCompLancement;
        /// <summary>
        /// 
        /// </summary>
        public ClassAffinite AffiniteAmelorationRes;
        /// <summary>
        /// 
        /// </summary>
        public ClassAffinite AffiniteReceptacleZeon;
        /// <summary>
        /// 
        /// </summary>
        public ClassAffinite AffiniteRechargeMag;
        /// <summary>
        /// 
        /// </summary>
        public ClassAffinite AffiniteAmpliAMR;
        /// <summary>
        /// 
        /// </summary>
        public ClassAffinite AffiniteProjMag;
        /// <summary>
        /// 
        /// </summary>
        public ClassAffinite AffinitePuissAjoutee;
        /// <summary>
        /// 
        /// </summary>
        public ClassAffinite AffiniteAltDestin;
        /// <summary>
        /// 
        /// </summary>
        public ClassAffinite AffiniteAugmentCharac;
        /// <summary>
        /// 
        /// </summary>
        public ClassAffinite AffiniteAugmentCompSec;
        /// <summary>
        /// 
        /// </summary>
        public ClassAffinite AffiniteImmunitePsy;
        /// <summary>
        /// 
        /// </summary>
        public ClassAffinite AffiniteImmunite;
        /// <summary>
        /// 
        /// </summary>
        public ClassAffinite AffiniteAmelioMaintPouvoir;
        /// <summary>
        /// 
        /// </summary>
        public ClassAffinite AffiniteAugmentDeplacement;
        /// <summary>
        /// 
        /// </summary>
        public ClassAffinite AffiniteImmuniteElem;
        /// <summary>
        /// 
        /// </summary>
        public ClassAffinite AffinitePresAccru;
        /// <summary>
        /// 
        /// </summary>
        public ClassAffinite AffiniteConvoAccrue;
        /// <summary>
        /// 
        /// </summary>
        public ClassAffinite AffiniteEffetMystique;
        /// <summary>
        /// 
        /// </summary>
        public ClassAffinite AffiniteReserveKi;
        /// <summary>
        /// 
        /// </summary>
        public ClassAffinite AffiniteTalent;
        /// <summary>
        /// 
        /// </summary>
        public ClassAffinite AffiniteAttElement;
        /// <summary>
        /// 
        /// </summary>
        public ClassAffinite AffiniteSubstiCarac;
        /// <summary>
        /// 
        /// </summary>
        public ClassAffinite AffiniteAttSpec;
        /// <summary>
        /// 
        /// </summary>
        public ClassAffinite AffiniteSeuilInvul;
        /// <summary>
        /// 
        /// </summary>
        public ClassAffinite AffiniteImmuniteMystique;
        /// <summary>
        /// 
        /// </summary>
        public ClassAffinite AffiniteTestResAccrus;
        /// <summary>
        /// 
        /// </summary>
        public ClassAffinite AffiniteCreatePortail;
        /// <summary>
        /// 
        /// </summary>
        public ClassAffinite AffiniteLanceurSort;
        /// <summary>
        /// 
        /// </summary>
        public ClassAffinite AffiniteVision;
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public ClassContenant()
        {
            //initialization des variables
            Materiel = 0;
            Qualite = 0;
            PresenceBase = 0;
            PresenceTotal = 0;
            TypeObjet = "";
            Exclusif = false;
            AffiniteSortsAuto = new ClassAffinite();
            AffiniteMagieInnee = new ClassAffinite();
            AffiniteCompLancement = new ClassAffinite();
            AffiniteAmelorationRes = new ClassAffinite();
            AffiniteReceptacleZeon = new ClassAffinite();
            AffiniteRechargeMag = new ClassAffinite();
            AffiniteAmpliAMR = new ClassAffinite();
            AffiniteProjMag = new ClassAffinite();
            AffinitePuissAjoutee = new ClassAffinite();
            AffiniteAltDestin = new ClassAffinite();
            AffiniteAugmentCharac = new ClassAffinite();
            AffiniteAugmentCompSec = new ClassAffinite();
            AffiniteImmunite = new ClassAffinite();
            AffiniteImmunitePsy = new ClassAffinite();
            AffiniteAmelioMaintPouvoir = new ClassAffinite();
            AffiniteAugmentDeplacement = new ClassAffinite();
            AffiniteImmuniteElem = new ClassAffinite();
            AffinitePresAccru = new ClassAffinite();
            AffiniteConvoAccrue = new ClassAffinite();
            AffiniteEffetMystique = new ClassAffinite();
            AffiniteReserveKi = new ClassAffinite();
            AffiniteTalent = new ClassAffinite();
            AffiniteAttElement = new ClassAffinite();
            AffiniteSubstiCarac = new ClassAffinite();
            AffiniteAttSpec = new ClassAffinite();
            AffiniteSeuilInvul = new ClassAffinite();
            AffiniteImmuniteMystique = new ClassAffinite();
            AffiniteTestResAccrus = new ClassAffinite();
            AffiniteCreatePortail = new ClassAffinite();
            AffiniteLanceurSort = new ClassAffinite();
            AffiniteVision = new ClassAffinite();
        }

        /// <summary>
        /// Construit et retourne un string contenant la description de l'item
        /// </summary>
        public void DescriptionObjet(List<string> description)
        {
            description.Add(TypeObjet + " fait en " + Properties.Settings.Default.Materiel[Materiel].ToString() + ".");

            description.Add(Properties.Settings.Default.BonusQualiteItem[Qualite] + ".");

            if (Exclusif)
            {
                description.Add("Fait pour être un artéfact.");
            }

            description.Add("Affinité :");
            string temp = "     Aucune.";
            if (AffiniteSortsAuto.HasAffinite())
            {
                temp = "     Sort Automatique.";
                description.Add(temp);
            }
            if (AffiniteMagieInnee.HasAffinite())
            {
                temp = "     Magie innée.";
                description.Add(temp);
            }
            if (AffiniteCompLancement.HasAffinite())
            {
                temp = "     Compétence de lancement.";
                description.Add(temp);
            }
            if (AffiniteAmelorationRes.HasAffinite())
            {
                temp = "     Amélioration de s resistances.";
                description.Add(temp);
            }
            if (AffiniteReceptacleZeon.HasAffinite())
            {
                temp = "     Réceptacle de Zéon.";
                description.Add(temp);
            }
            if (AffiniteRechargeMag.HasAffinite())
            {
                temp = "     Recharge magique.";
                description.Add(temp);
            }
            if (AffiniteAmpliAMR.HasAffinite())
            {
                temp = "     Amplification de l'AMR.";
                description.Add(temp);
            }
            if (AffiniteProjMag.HasAffinite())
            {
                temp = "     Projection magique.";
                description.Add(temp);
            }
            if (AffinitePuissAjoutee.HasAffinite())
            {
                temp = "     Puissance ajouté.";
                description.Add(temp);
            }
            if (AffiniteAltDestin.HasAffinite())
            {
                temp = "     Altération du destin.";
                description.Add(temp);
            }
            if (AffiniteMagieInnee.HasAffinite())
            {
                temp = "     Magie innée.";
                description.Add(temp);
            }
            if (AffiniteAugmentCharac.HasAffinite())
            {
                temp = "     Augmentation des caractéristiques.";
                description.Add(temp);
            }
            if (AffiniteAugmentCompSec.HasAffinite())
            {
                temp = "     Augementation des compétences secondaires.";
                description.Add(temp);
            }
            if (AffiniteImmunite.HasAffinite())
            {
                temp = "     Immunité.";
                description.Add(temp);
            }
            if (AffiniteAmelioMaintPouvoir.HasAffinite())
            {
                temp = "     Amélioration du maintien des pouvoirs.";
                description.Add(temp);
            }
            if (AffiniteAugmentDeplacement.HasAffinite())
            {
                temp = "     Augmentation du déplacement.";
                description.Add(temp);
            }
            if (AffiniteImmuniteElem.HasAffinite())
            {
                temp = "     Imunité élémentaire.";
                description.Add(temp);
            }
            if (AffinitePresAccru.HasAffinite())
            {
                temp = "     Présence accrue.";
                description.Add(temp);
            }
            if (AffiniteConvoAccrue.HasAffinite())
            {
                temp = "     Convocation accrue.";
                description.Add(temp);
            }
            if (AffiniteEffetMystique.HasAffinite())
            {
                temp = "     Effet mystique.";
                description.Add(temp);
            }
            if (AffiniteReserveKi.HasAffinite())
            {
                temp = "     Réserve de ki.";
                description.Add(temp);
            }
            if (AffiniteTalent.HasAffinite())
            {
                temp = "     Talent.";
                description.Add(temp);
            }
            if (AffiniteAttElement.HasAffinite())
            {
                temp = "     Attaques élémentaires.";
                description.Add(temp);
            }
            if (AffiniteSubstiCarac.HasAffinite())
            {
                temp = "     Substitution de caractéristique.";
                description.Add(temp);
            }
            if (AffiniteAttSpec.HasAffinite())
            {
                temp = "     Attaque spéciale.";
                description.Add(temp);
            }
            if (AffiniteSeuilInvul.HasAffinite())
            {
                temp = "     Seuil d'invulnérabilté.";
                description.Add(temp);
            }
            if (AffiniteImmuniteMystique.HasAffinite())
            {
                temp = "     Immunité magique.";
                description.Add(temp);
            }
            if (AffiniteImmunitePsy.HasAffinite())
            {
                temp = "     Immunité psychique.";
                description.Add(temp);
            }
            if (AffiniteTestResAccrus.HasAffinite())
            {
                temp = "     Test de résistance mystique et/ou psychique accrus.";
                description.Add(temp);
            }
            if (AffiniteCreatePortail.HasAffinite())
            {
                temp = "     Créateur de portail.";
                description.Add(temp);
            }
            if (AffiniteLanceurSort.HasAffinite())
            {
                temp = "     Lanceur de sorts.";
                description.Add(temp);
            }
            if (AffiniteVision.HasAffinite())
            {
                temp = "     Moyens spéciaux de vision.";
                description.Add(temp);
            }

            description.Add("\nPrésence totale de l'item : " + PresenceTotal);
        }

        public string DescriptionObjetUneLigne()
        {
            string tempDesc = TypeObjet + " Presence totale: " + PresenceTotal + ".";

            return tempDesc;
        }

        /// <summary>
        /// Ajoute le contenant en format XML au writer
        /// </summary>
        /// <param name="writer">le fichier/stream du XML</param>
        public void ExportXML(XmlWriter writer)
        {
            writer.WriteStartElement("contenant");

            writer.WriteStartElement("Materiel");
            writer.WriteValue(Materiel);
            writer.WriteEndElement();
            writer.WriteStartElement("Qualite");
            writer.WriteValue(Qualite);
            writer.WriteEndElement();
            writer.WriteStartElement("PresenceBase");
            writer.WriteValue(PresenceBase);
            writer.WriteEndElement();
            writer.WriteElementString("TypeObjet", TypeObjet);
            if (Exclusif)
            {
                writer.WriteStartElement("Exclusif");
                writer.WriteValue(Exclusif);
                writer.WriteEndElement();
            }
            if (AffiniteSortsAuto.GetAffinite() != 0)
            {
                writer.WriteStartElement("AffiniteSortsAuto");
                writer.WriteValue(AffiniteSortsAuto.GetAffinite());
                writer.WriteEndElement();
            }
            if (AffiniteMagieInnee.GetAffinite() != 0)
            {
                writer.WriteStartElement("AffiniteMagieInnee");
                writer.WriteValue(AffiniteMagieInnee.GetAffinite());
                writer.WriteEndElement();
            }
            if (AffiniteCompLancement.GetAffinite() != 0)
            {
                writer.WriteStartElement("AffiniteCompLancement");
                writer.WriteValue(AffiniteCompLancement.GetAffinite());
                writer.WriteEndElement();
            }
            if (AffiniteAmelorationRes.GetAffinite() != 0)
            {
                writer.WriteStartElement("AffiniteAmelorationRes");
                writer.WriteValue(AffiniteAmelorationRes);
                writer.WriteEndElement();
            }
            if (AffiniteReceptacleZeon.GetAffinite() != 0)
            {
                writer.WriteStartElement("AffiniteReceptacleZeon");
                writer.WriteValue(AffiniteReceptacleZeon.GetAffinite());
                writer.WriteEndElement();
            }
            if (AffiniteRechargeMag.GetAffinite() != 0)
            {
                writer.WriteStartElement("AffiniteRechargeMag");
                writer.WriteValue(AffiniteRechargeMag.GetAffinite());
                writer.WriteEndElement();
            }
            if (AffiniteAmpliAMR.GetAffinite() != 0)
            {
                writer.WriteStartElement("AffiniteAmpliAMR");
                writer.WriteValue(AffiniteAmpliAMR.GetAffinite());
                writer.WriteEndElement();
            }
            if (AffiniteProjMag.GetAffinite() != 0)
            {
                writer.WriteStartElement("AffiniteProjMag");
                writer.WriteValue(AffiniteProjMag.GetAffinite());
                writer.WriteEndElement();
            }
            if (AffinitePuissAjoutee.GetAffinite() != 0)
            {
                writer.WriteStartElement("AffinitePuissAjoutee");
                writer.WriteValue(AffinitePuissAjoutee.GetAffinite());
                writer.WriteEndElement();
            }
            if (AffiniteAltDestin.GetAffinite() != 0)
            {
                writer.WriteStartElement("AffiniteAltDestin");
                writer.WriteValue(AffiniteAltDestin.GetAffinite());
                writer.WriteEndElement();
            }
            if (AffiniteAugmentCharac.GetAffinite() != 0)
            {
                writer.WriteStartElement("AffiniteAugmentCharac");
                writer.WriteValue(AffiniteAugmentCharac.GetAffinite());
                writer.WriteEndElement();
            }
            if (AffiniteAugmentCompSec.GetAffinite() != 0)
            {
                writer.WriteStartElement("AffiniteAugmentCompSec");
                writer.WriteValue(AffiniteAugmentCompSec.GetAffinite());
                writer.WriteEndElement();
            }
            if (AffiniteImmunitePsy.GetAffinite() != 0)
            {
                writer.WriteStartElement("AffiniteImmunitePsy");
                writer.WriteValue(AffiniteImmunitePsy.GetAffinite());
                writer.WriteEndElement();
            }
            if (AffiniteImmunite.GetAffinite() != 0)
            {
                writer.WriteStartElement("AffiniteImmunite");
                writer.WriteValue(AffiniteImmunite.GetAffinite());
                writer.WriteEndElement();
            }
            if (AffiniteAmelioMaintPouvoir.GetAffinite() != 0)
            {
                writer.WriteStartElement("AffiniteAmelioMaintPouvoir");
                writer.WriteValue(AffiniteAmelioMaintPouvoir.GetAffinite());
                writer.WriteEndElement();
            }
            if (AffiniteAugmentDeplacement.GetAffinite() != 0)
            {
                writer.WriteStartElement("AffiniteAugmentDeplacement");
                writer.WriteValue(AffiniteAugmentDeplacement.GetAffinite());
                writer.WriteEndElement();
            }
            if (AffinitePresAccru.GetAffinite() != 0)
            {
                writer.WriteStartElement("AffinitePresAccru");
                writer.WriteValue(AffinitePresAccru.GetAffinite());
                writer.WriteEndElement();
            }
            if (AffiniteConvoAccrue.GetAffinite() != 0)
            {
                writer.WriteStartElement("AffiniteConvoAccrue");
                writer.WriteValue(AffiniteConvoAccrue.GetAffinite());
                writer.WriteEndElement();
            }
            if (AffiniteEffetMystique.GetAffinite() != 0)
            {
                writer.WriteStartElement("AffiniteEffetMystique");
                writer.WriteValue(AffiniteEffetMystique.GetAffinite());
                writer.WriteEndElement();
            }
            if (AffiniteReserveKi.GetAffinite() != 0)
            {
                writer.WriteStartElement("AffiniteReserveKi");
                writer.WriteValue(AffiniteReserveKi.GetAffinite());
                writer.WriteEndElement();
            }
            if (AffiniteTalent.GetAffinite() != 0)
            {
                writer.WriteStartElement("AffiniteTalent");
                writer.WriteValue(AffiniteTalent.GetAffinite());
                writer.WriteEndElement();
            }
            if (AffiniteAttElement.GetAffinite() != 0)
            {
                writer.WriteStartElement("AffiniteAttElement");
                writer.WriteValue(AffiniteAttElement.GetAffinite());
                writer.WriteEndElement();
            }
            if (AffiniteSubstiCarac.GetAffinite() != 0)
            {
                writer.WriteStartElement("AffiniteSubstiCarac");
                writer.WriteValue(AffiniteSubstiCarac.GetAffinite());
                writer.WriteEndElement();
            }
            if (AffiniteAttSpec.GetAffinite() != 0)
            {
                writer.WriteStartElement("AffiniteAttSpec");
                writer.WriteValue(AffiniteAttSpec.GetAffinite());
                writer.WriteEndElement();
            }
            if (AffiniteSeuilInvul.GetAffinite() != 0)
            {
                writer.WriteStartElement("AffiniteSeuilInvul");
                writer.WriteValue(AffiniteSeuilInvul.GetAffinite());
                writer.WriteEndElement();
            }
            if (AffiniteImmuniteMystique.GetAffinite() != 0)
            {
                writer.WriteStartElement("AffiniteImmuniteMystique");
                writer.WriteValue(AffiniteImmuniteMystique.GetAffinite());
                writer.WriteEndElement();
            }
            if (AffiniteTestResAccrus.GetAffinite() != 0)
            {
                writer.WriteStartElement("AffiniteTestResAccrus");
                writer.WriteValue(AffiniteTestResAccrus.GetAffinite());
                writer.WriteEndElement();
            }
            if (AffiniteCreatePortail.GetAffinite() != 0)
            {
                writer.WriteStartElement("AffiniteCreatePortail");
                writer.WriteValue(AffiniteCreatePortail.GetAffinite());
                writer.WriteEndElement();
            }
            if (AffiniteLanceurSort.GetAffinite() != 0)
            {
                writer.WriteStartElement("AffiniteLanceurSort");
                writer.WriteValue(AffiniteLanceurSort.GetAffinite());
                writer.WriteEndElement();
            }
            if (AffiniteVision.GetAffinite() != 0)
            {
                writer.WriteStartElement("AffiniteVision");
                writer.WriteValue(AffiniteVision.GetAffinite());
                writer.WriteEndElement();
            }
        }

        /// <summary>
        /// Reset les affinités
        /// </summary>
        public void ResetAffinite()
        {
            if (AffiniteAltDestin.HasAffinite())
            {
                AffiniteAltDestin = new ClassAffinite(20);
            }
            if (AffiniteAmelioMaintPouvoir.HasAffinite())
            {
                AffiniteAmelioMaintPouvoir = new ClassAffinite(20);
            }
            if (AffiniteAmelorationRes.HasAffinite())
            {
                AffiniteAmelorationRes = new ClassAffinite(20);
            }
            if (AffiniteAmpliAMR.HasAffinite())
            {
                AffiniteAmpliAMR = new ClassAffinite(20);
            }
            if (AffiniteAttElement.HasAffinite())
            {
                AffiniteAttElement = new ClassAffinite(20);
            }
            if (AffiniteAttSpec.HasAffinite())
            {
                AffiniteAttSpec = new ClassAffinite(20);
            }
            if (AffiniteAugmentCharac.HasAffinite())
            {
                AffiniteAugmentCharac = new ClassAffinite(20);
            }
            if (AffiniteAugmentCompSec.HasAffinite())
            {
                AffiniteAugmentCompSec = new ClassAffinite(20);
            }
            if (AffiniteAugmentDeplacement.HasAffinite())
            {
                AffiniteAugmentDeplacement = new ClassAffinite(20);
            }
            if (AffiniteCompLancement.HasAffinite())
            {
                AffiniteCompLancement = new ClassAffinite(20);
            }
            if (AffiniteConvoAccrue.HasAffinite())
            {
                AffiniteConvoAccrue = new ClassAffinite(20);
            }
            if (AffiniteCreatePortail.HasAffinite())
            {
                AffiniteCreatePortail = new ClassAffinite(20);
            }
            if (AffiniteEffetMystique.HasAffinite())
            {
                AffiniteEffetMystique = new ClassAffinite(20);
            }
            if (AffiniteImmunite.HasAffinite())
            {
                AffiniteImmunite = new ClassAffinite(20);
            }
            if (AffiniteImmuniteElem.HasAffinite())
            {
                AffiniteImmuniteElem = new ClassAffinite(20);
            }
            if (AffiniteImmuniteMystique.HasAffinite())
            {
                AffiniteImmuniteMystique = new ClassAffinite(20);
            }
            if (AffiniteImmunitePsy.HasAffinite())
            {
                AffiniteImmunitePsy = new ClassAffinite(20);
            }
            if (AffiniteLanceurSort.HasAffinite())
            {
                AffiniteLanceurSort = new ClassAffinite(20);
            }
            if (AffiniteMagieInnee.HasAffinite())
            {
                AffiniteMagieInnee = new ClassAffinite(20);
            }
            if (AffinitePresAccru.HasAffinite())
            {
                AffinitePresAccru = new ClassAffinite(20);
            }
            if (AffiniteProjMag.HasAffinite())
            {
                AffiniteProjMag = new ClassAffinite(20);
            }
            if (AffinitePuissAjoutee.HasAffinite())
            {
                AffinitePuissAjoutee = new ClassAffinite(20);
            }
            if (AffiniteReceptacleZeon.HasAffinite())
            {
                AffiniteReceptacleZeon = new ClassAffinite(20);
            }
            if (AffiniteRechargeMag.HasAffinite())
            {
                AffiniteRechargeMag = new ClassAffinite(20);
            }
            if (AffiniteReserveKi.HasAffinite())
            {
                AffiniteReserveKi = new ClassAffinite(20);
            }
            if (AffiniteSeuilInvul.HasAffinite())
            {
                AffiniteSeuilInvul = new ClassAffinite(20);
            }
            if (AffiniteSortsAuto.HasAffinite())
            {
                AffiniteSortsAuto = new ClassAffinite(20);
            }
            if (AffiniteSubstiCarac.HasAffinite())
            {
                AffiniteSubstiCarac = new ClassAffinite(20);
            }
            if (AffiniteTalent.HasAffinite())
            {
                AffiniteTalent = new ClassAffinite(20);
            }
            if (AffiniteTestResAccrus.HasAffinite())
            {
                AffiniteTestResAccrus = new ClassAffinite(20);
            }
            if (AffiniteVision.HasAffinite())
            {
                AffiniteVision = new ClassAffinite(20);
            }
        }
    }

    /// <summary>
    /// La liste des différents type de facette.
    /// </summary>
    public enum TypeFacette
    {
        /// <summary>
        /// Valeur null
        /// </summary>
        Aucune,
        /// <summary>
        /// Les différents types de facettes
        /// </summary>
        FacetteQualite,
        FacetteCombat,
        FacetteDefensive,
        FacetteProtection,
        FacetteMagique,
        FacettePsychique,
        FacetteConvocation,
        FacetteInnee,
        FacetteAugmentation,
        FacetteMaitrise,
        FacetteEsoterique,
        FacetteAutre
    }

    /// <summary>
    /// La liste des différents sous type de facette
    /// </summary>
    public enum SubTypeFacette
    {
        /// <summary>
        /// Valeur null
        /// </summary>
        Aucune,
        /// <summary>
        /// Les différents sous types de facettes
        /// </summary>
        AttaqueSpeciale,
        EffetMystique
    }

    /// <summary>
    /// 
    /// </summary>
    public class ClassCoutPouvoir
    {
        /// <summary>
        /// 
        /// </summary>
        public int Niveau;
        /// <summary>
        /// 
        /// </summary>
        public int PP;
        /// <summary>
        /// 
        /// </summary>
        public int Presence;

        public ClassCoutPouvoir(int pp = 0, int niv = 0, int presence = 0)
        {
            Niveau = niv;
            PP = pp;
            Presence = presence;
        }

        /// <summary>
        /// Génère la cout en présence pour le niveau
        /// </summary>
        /// <returns>La présence si niveau valide, -1 sinon</returns>
        public int GeneratePresence()
        {
            switch(Niveau)
            {
                case 1:
                    Presence = 10;
                    break;
                case 2:
                    Presence = 15;
                    break;
                case 3:
                    Presence = 25;
                    break;
                case 4:
                    Presence = 60;
                    break;
                case 5:
                    Presence = 100;
                    break;
                default:
                    Presence = -1;
                    break;

            }

            return Presence;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class ClassFacette
    {
        /// <summary>
        /// 
        /// </summary>
        public TypeFacette TypePouvoir;
        public SubTypeFacette SubType = SubTypeFacette.Aucune;
        internal ClassCoutPouvoir CoutPouvoir;

        /// <summary>
        /// Génère la description du pouvoir
        /// </summary>
        /// <returns>La desscription du pouvoir</returns>
        public abstract void DescriptionPouvoir(List<string> description);

        /// <summary>
        /// Génère la description du pouvoir
        /// </summary>
        /// <returns>La desscription du pouvoir</returns>
        public abstract string DescriptionPouvoirUneLigne();

        /// <summary>
        /// Génère et/ou retourne le cout du pouvoir
        /// </summary>
        /// <returns>Le cout du pouvoir</returns>
        public ClassCoutPouvoir GetCoutPouvoir()
        {
            if (CoutPouvoir.Niveau == 0)
            {
                GenererCoutPouvoir();
            }

            return CoutPouvoir;
        }

        /// <summary>
        /// Génère le cout du pouvoir.
        /// </summary>
        /// <returns>Le cout du pouvoir.</returns>
        public abstract void GenererCoutPouvoir();

        /// <summary>
        /// Construit le XML a exporter
        /// </summary>
        /// <param name="writer">Le fichier/stream du XML</param>
        public abstract void ExportXML(XmlWriter writer);
    }

    /// <summary>
    /// 
    /// </summary>
    public class ClassFacetteQualite : ClassFacette
    {
        /// <summary>
        /// index 0 = 0, 1 = +5, 2 = +10, 3 = +15, 4 = +20, 5 = +25
        /// </summary>
        public int Combat { get; set; }
        /// <summary>
        /// index 0 = 0, 1 = +5, 2 = +10, 3 = +15, 4 = +20, 5 = +25
        /// </summary>
        public int Generale { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ClassFacetteQualite()
        {
            //initialization des variables
            TypePouvoir = TypeFacette.FacetteQualite;
            CoutPouvoir = new ClassCoutPouvoir(0, 0, 0);

            Combat = 0;
            Generale = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override void DescriptionPouvoir(List<string> description)
        {
            string tempDesc = "Aucun bonus";

            if (Combat != 0)
            {
                tempDesc = "Bonus de combat de +";
                switch (Combat)
                {
                    case 1:
                        tempDesc += "5.";
                        break;
                    case 2:
                        tempDesc += "10.";
                        break;
                    case 3:
                        tempDesc += "15.";
                        break;
                    case 4:
                        tempDesc += "20.";
                        break;
                    case 5:
                        tempDesc += "25.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme";
                        break;
                }
            }
            else if (Generale != 0)
            {
                tempDesc = "Bonus général de +";
                switch (Generale)
                {
                    case 1:
                        tempDesc += "5.";
                        break;
                    case 2:
                        tempDesc += "10.";
                        break;
                    case 3:
                        tempDesc += "15.";
                        break;
                    case 4:
                        tempDesc += "20.";
                        break;
                    case 5:
                        tempDesc += "25.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            description.Add(tempDesc);

            tempDesc = "PP: " + CoutPouvoir.PP + " niveau: " + CoutPouvoir.Niveau + " présence: " + CoutPouvoir.Presence + ".";
            description.Add(tempDesc);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override void GenererCoutPouvoir()
        {
            CoutPouvoir = new ClassCoutPouvoir(0, 0, 0);

            if (Combat != 0)
            {
                switch (Combat)
                {
                    case 1:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 2:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 3:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 4:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 4;
                        break;
                    case 5:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 5;
                        break;
                    default:
                        break;
                }
            }
            else if (Generale != 0)
            {
                switch (Generale)
                {
                    case 1:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 1;
                        break;
                    case 2:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 1;
                        break;
                    case 3:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 4:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 5:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 4;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                CoutPouvoir.PP = 0;
                CoutPouvoir.Niveau = 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        public override void ExportXML(XmlWriter writer)
        {
            writer.WriteStartElement("ClassFacetteQualite");

            writer.WriteStartElement("TypePouvoir");
            writer.WriteValue((int)TypePouvoir);
            writer.WriteEndElement();

            writer.WriteStartElement("CoutPouvoir");
            writer.WriteStartElement("PP");
            writer.WriteValue(CoutPouvoir.PP);
            writer.WriteEndElement();
            writer.WriteStartElement("Niveau");
            writer.WriteValue(CoutPouvoir.Niveau);
            writer.WriteEndElement();
            writer.WriteEndElement();

            if (Combat > 0)
            {
                writer.WriteStartElement("Combat");
                writer.WriteValue(Combat);
                writer.WriteEndElement();
            }
            else if (Generale > 0)
            {
                writer.WriteStartElement("Generale");
                writer.WriteValue(Generale);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        public override string DescriptionPouvoirUneLigne()
        {
            string tempDesc = "Aucun bonus";

            if (Combat != 0)
            {
                tempDesc = "Bonus de combat de +";
                switch (Combat)
                {
                    case 1:
                        tempDesc += "5.";
                        break;
                    case 2:
                        tempDesc += "10.";
                        break;
                    case 3:
                        tempDesc += "15.";
                        break;
                    case 4:
                        tempDesc += "20.";
                        break;
                    case 5:
                        tempDesc += "25.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme";
                        break;
                }
            }
            else if (Generale != 0)
            {
                tempDesc = "Bonus général de +";
                switch (Generale)
                {
                    case 1:
                        tempDesc += "5.";
                        break;
                    case 2:
                        tempDesc += "10.";
                        break;
                    case 3:
                        tempDesc += "15.";
                        break;
                    case 4:
                        tempDesc += "20.";
                        break;
                    case 5:
                        tempDesc += "25.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            return tempDesc;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ClassFacetteCombat : ClassFacette
    {
        /// <summary>
        /// index 0 = 0, 1 = +5, 2 = +10, 3 = +15, 4 = +20, 5 = +25
        /// </summary>
        public int Attaque { get; set; }
        /// <summary>
        /// index 0 = 0, 1 = +5, 2 = +10, 3 = +15, 4 = +20
        /// </summary>
        public int Offensif { get; set; }
        /// <summary>
        /// index 0 = 0, 1 = +10, 2 = +20, 3 = +30, 4 = +40, 5 = +50, 6 = +60, 7 = +80, 8 = +100
        /// </summary>
        public int BonusDegat { get; set; }
        /// <summary>
        /// index 1  = un type de race, 2 = un être, 3 = condition
        /// </summary>
        public int Exterminateur { get; set; }
        /// <summary>
        /// index 1  = impact = force plus petit 12, 2 = impact = force(no limit), 3 = impact 8, 4 = impact 10, 5 = 12, 6 = 15
        /// </summary>
        public int Assaut { get; set; }
        /// <summary>
        /// index 1  = 10/jour, 2 = 25/jour, 3 = 100/jour, 4 = infinis
        /// </summary>
        public int Munition { get; set; }
        /// <summary>
        /// bonus au critique par index de 10, si 100 automatique
        /// </summary>
        public int Critique { get; set; }
        /// <summary>
        /// index 1 = actif, 2 = passif, 3 = a vue, 4 = a proximité, 5 = illimité
        /// </summary>
        public int Recuperation { get; set; }
        /// <summary>
        /// index 1 = -1IP, 2 = -2IP, 3 = -3IP, 4 = -4IP, 5 = -5IP, 6 = -6IP, 7 = -8IP, 8 = ignore IP
        /// </summary>
        public int DestArmure { get; set; }
        /// <summary>
        /// index 1 = enchantée, 2 = Surnaturelle
        /// </summary>
        public int Enchantee { get; set; }
        /// <summary>
        /// index 1 = froid, 2 = feu, 3 = Électricité, 4 = Lumière, 5 = Obscurité, 6 = Énergie, 7 = Terre ou Eau ou Air
        /// </summary>
        public int Element { get; set; }
        /// <summary>
        /// modificateur pour les effets élémentaires
        /// </summary>
        public bool ElemVariable { get; set; }
        /// <summary>
        /// modificateur pour les effets élémentaires
        /// </summary>
        public bool ElemCombine { get; set; }
        /// <summary>
        /// modificateur pour les effets élémentaires
        /// </summary>
        public bool ElemPrime { get; set; }
        /// <summary>
        /// modificateur pour l'effet exterminateur
        /// </summary>
        public bool GrandExterminateur { get; set; }
        /// <summary>
        /// modificateur pour l'effet munition
        /// </summary>
        public bool Firearm { get; set; }
        /// <summary>
        /// modificateur pour l'effet munition
        /// </summary>
        public bool MuniCombi { get; set; }
        /// <summary>
        /// nom de la race ou de l'individu associé a l'effet exterminateur ou de la condition
        /// </summary>
        public string DescExterminateur { get; set; }
        /// <summary>
        /// index 1 = précise, 2 = vorpal, 3 = mode variable, 4 = transform limité, 5 = transform complète, 6 = corntôle des dégats
        /// </summary>
        public int AutreComp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ClassFacetteCombat()
        {
            //initialization des variables
            TypePouvoir = TypeFacette.FacetteCombat;
            SubType = SubTypeFacette.Aucune;
            Attaque = 0;
            Offensif = 0;
            BonusDegat = 0;
            Exterminateur = 0;
            Assaut = 0;
            Munition = 0;
            Critique = 0;
            Recuperation = 0;
            DestArmure = 0;
            Enchantee = 0;
            Element = 0;
            AutreComp = 0;
            ElemVariable = false;
            ElemCombine = false;
            ElemPrime = false;
            GrandExterminateur = false;
            Firearm = false;
            MuniCombi = false;
            DescExterminateur = "";

            CoutPouvoir = new ClassCoutPouvoir(0, 0, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override void DescriptionPouvoir(List<string> description)
        {
            string tempDesc = "";

            if (Attaque != 0)
            {
                tempDesc = "Arme à l'attaque accrue: ";
                switch (Attaque)
                {
                    case 1:
                        tempDesc += "+5.";
                        break;
                    case 2:
                        tempDesc += "+10.";
                        break;
                    case 3:
                        tempDesc += "+15.";
                        break;
                    case 4:
                        tempDesc += "+20.";
                        break;
                    case 5:
                        tempDesc += "+25.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
                description.Add(tempDesc);
            }
            else if (Offensif != 0)
            {
                tempDesc = "Renforcement offensif: ";
                switch (Offensif)
                {
                    case 1:
                        tempDesc += "+5.";
                        break;
                    case 2:
                        tempDesc += "+10.";
                        break;
                    case 3:
                        tempDesc += "+15.";
                        break;
                    case 4:
                        tempDesc += "+20.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
                description.Add(tempDesc);
            }
            else if (BonusDegat != 0)
            {
                tempDesc = "Dégâts accrus: ";
                switch (BonusDegat)
                {
                    case 1:
                        tempDesc += "+10.";
                        break;
                    case 2:
                        tempDesc += "+20.";
                        break;
                    case 3:
                        tempDesc += "+30.";
                        break;
                    case 4:
                        tempDesc += "+40.";
                        break;
                    case 5:
                        tempDesc += "+50.";
                        break;
                    case 6:
                        tempDesc += "+60.";
                        break;
                    case 7:
                        tempDesc += "+80.";
                        break;
                    case 8:
                        tempDesc += "+100.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
                description.Add(tempDesc);
            }
            else if (Exterminateur != 0)
            {
                tempDesc = "Exterminateur: ";
                switch (Exterminateur)
                {
                    case 1:
                        tempDesc += "Un type de race: " + DescExterminateur + ".";
                        break;
                    case 2:
                        tempDesc += "Un être en particulier: " + DescExterminateur + ".";
                        break;
                    case 3:
                        tempDesc += "Une condition: " + DescExterminateur + ".";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
                description.Add(tempDesc);
                if (GrandExterminateur)
                {
                    tempDesc = "   Grand exterminateur.";
                    description.Add(tempDesc);
                }
            }
            else if (Assaut != 0)
            {
                tempDesc = "Assaut: ";
                switch (Assaut)
                {
                    case 1:
                        tempDesc += "Assaut.";
                        break;
                    case 2:
                        tempDesc += "Assaut majeur.";
                        break;
                    case 3:
                        tempDesc += "Force 8.";
                        break;
                    case 4:
                        tempDesc += "Force 10.";
                        break;
                    case 5:
                        tempDesc += "Force 12.";
                        break;
                    case 6:
                        tempDesc += "Force 15.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
                description.Add(tempDesc);
            }
            else if (Munition != 0)
            {
                tempDesc = "Munitions illimitées: ";
                switch (Munition)
                {
                    case 1:
                        tempDesc += "10 Projectiles par jour.";
                        break;
                    case 2:
                        tempDesc += "25 Projectiles par jour.";
                        break;
                    case 3:
                        tempDesc += "100 Projectiles par jour.";
                        break;
                    case 4:
                        tempDesc += "Projectiles infinis.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
                description.Add(tempDesc);
                if (Firearm)
                {
                    tempDesc = "   Armes à feu.";
                    description.Add(tempDesc);
                }
                if (MuniCombi)
                {
                    tempDesc = "   Munitions combinables";
                    description.Add(tempDesc);
                }
            }
            else if (Critique != 0)
            {
                tempDesc = "Critique accru: ";
                switch (Critique)
                {
                    case 1:
                        tempDesc += "+10.";
                        break;
                    case 2:
                        tempDesc += "+20.";
                        break;
                    case 3:
                        tempDesc += "+30.";
                        break;
                    case 4:
                        tempDesc += "+40.";
                        break;
                    case 5:
                        tempDesc += "+50.";
                        break;
                    case 6:
                        tempDesc += "+60.";
                        break;
                    case 7:
                        tempDesc += "Critique automatique.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
                description.Add(tempDesc);
            }
            else if (Recuperation != 0)
            {
                tempDesc = "Récupération: ";
                switch (Recuperation)
                {
                    case 1:
                        tempDesc += "Lancement (actif).";
                        break;
                    case 2:
                        tempDesc += "Lancement (passif).";
                        break;
                    case 3:
                        tempDesc += "À vue.";
                        break;
                    case 4:
                        tempDesc += "À proximité.";
                        break;
                    case 5:
                        tempDesc += "Illimitée.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
                description.Add(tempDesc);
            }
            else if (DestArmure != 0)
            {
                tempDesc = "Destruction d'armure: ";
                switch (DestArmure)
                {
                    case 1:
                        tempDesc += "IP -1.";
                        break;
                    case 2:
                        tempDesc += "IP -2.";
                        break;
                    case 3:
                        tempDesc += "IP -3.";
                        break;
                    case 4:
                        tempDesc += "IP -4.";
                        break;
                    case 5:
                        tempDesc += "IP -5.";
                        break;
                    case 6:
                        tempDesc += "IP -6.";
                        break;
                    case 7:
                        tempDesc += "IP -8.";
                        break;
                    case 8:
                        tempDesc += "IP ignoré.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
                description.Add(tempDesc);
            }
            else if (Element != 0)
            {
                tempDesc = "Attaques élémentaires: ";
                switch (Element)
                {
                    case 1:
                        tempDesc += "Froid.";
                        break;
                    case 2:
                        tempDesc += "Feu.";
                        break;
                    case 3:
                        tempDesc += "Électricité.";
                        break;
                    case 4:
                        tempDesc += "Lumière.";
                        break;
                    case 5:
                        tempDesc += "Obscurité.";
                        break;
                    case 6:
                        tempDesc += "Énergie.";
                        break;
                    case 7:
                        tempDesc += "Terre(PER) ou vent(TRA) ou eau(CON).";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
                description.Add(tempDesc);
                if (ElemVariable)
                {
                    tempDesc += "   Variable.";
                    description.Add(tempDesc);
                }
                else if (ElemCombine)
                {
                    tempDesc += "   Combiné.";
                    description.Add(tempDesc);
                }
                else if (ElemPrime)
                {
                    tempDesc += "   Primaire.";
                    description.Add(tempDesc);
                }
            }
            else if (Enchantee != 0)
            {
                tempDesc = "Enchantée: ";
                switch (Enchantee)
                {
                    case 1:
                        tempDesc += "Enchantée.";
                        break;
                    case 2:
                        tempDesc += "Surnaturelle.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
                description.Add(tempDesc);
            }
            else if (AutreComp != 0)
            {
                tempDesc = "Autre compétences d'armes: ";
                switch (AutreComp)
                {
                    case 1:
                        tempDesc += "Précise.";
                        break;
                    case 2:
                        tempDesc += "Vorpale.";
                        break;
                    case 3:
                        tempDesc += "Mode variable.";
                        break;
                    case 4:
                        tempDesc += "Transformation(limitée).";
                        break;
                    case 5:
                        tempDesc += "Transformation(complète).";
                        break;
                    case 6:
                        tempDesc += "Contrôle des dégâts.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
                description.Add(tempDesc);
            }

            description.Add("PP: " + CoutPouvoir.PP + " niveau: " + CoutPouvoir.Niveau + ".");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override void GenererCoutPouvoir()
        {
            CoutPouvoir = new ClassCoutPouvoir(0, 0);

            if (Attaque != 0)
            {
                switch (Attaque)
                {
                    case 1:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 1;
                        break;
                    case 2:
                        CoutPouvoir.PP = 20;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 3:
                        CoutPouvoir.PP = 20;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 4:
                        CoutPouvoir.PP = 20;
                        CoutPouvoir.Niveau = 4;
                        break;
                    case 5:
                        CoutPouvoir.PP = 10;
                        CoutPouvoir.Niveau = 5;
                        break;
                }
            }
            if (Offensif != 0)
            {
                switch (Offensif)
                {
                    case 1:
                        CoutPouvoir.PP = 60;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 2:
                        CoutPouvoir.PP = 120;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 3:
                        CoutPouvoir.PP = 60;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 4:
                        CoutPouvoir.PP = 60;
                        CoutPouvoir.Niveau = 4;
                        break;
                }
            }
            if (BonusDegat != 0)
            {
                switch (BonusDegat)
                {
                    case 1:
                        CoutPouvoir.PP = 20;
                        CoutPouvoir.Niveau = 1;
                        break;
                    case 2:
                        CoutPouvoir.PP = 80;
                        CoutPouvoir.Niveau = 1;
                        break;
                    case 3:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 4:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 5:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 6:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 7:
                        CoutPouvoir.PP = 40;
                        CoutPouvoir.Niveau = 4;
                        break;
                    case 8:
                        CoutPouvoir.PP = 80;
                        CoutPouvoir.Niveau = 4;
                        break;
                }
            }
            if (Exterminateur != 0)
            {
                switch (Exterminateur)
                {
                    case 1:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 2:
                        CoutPouvoir.PP = 20;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 3:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 2;
                        break;
                }
                if (GrandExterminateur)
                {
                    CoutPouvoir.PP += 50;
                }
            }
            if (Assaut != 0)
            {
                switch (Assaut)
                {
                    case 1:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 2:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 3:
                        CoutPouvoir.PP = 20;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 4:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 5:
                        CoutPouvoir.PP = 20;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 6:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 3;
                        break;
                }
            }
            if (Munition != 0)
            {
                switch (Munition)
                {
                    case 1:
                        CoutPouvoir.PP = 20;
                        CoutPouvoir.Niveau = 1;
                        break;
                    case 2:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 1;
                        break;
                    case 3:
                        CoutPouvoir.PP = 20;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 4:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 2;
                        break;
                }
                if (Firearm)
                {
                    CoutPouvoir.PP += 20;
                }
                if (MuniCombi)
                {
                    CoutPouvoir.PP += 20;
                }
            }
            if (Critique != 0)
            {
                switch (Critique)
                {
                    case 1:
                        CoutPouvoir.PP = 40;
                        CoutPouvoir.Niveau = 1;
                        break;
                    case 2:
                        CoutPouvoir.PP = 40;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 3:
                        CoutPouvoir.PP = 80;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 4:
                        CoutPouvoir.PP = 20;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 5:
                        CoutPouvoir.PP = 60;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 6:
                        CoutPouvoir.PP = 150;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 7:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 4;
                        break;
                }
            }
            if (Recuperation != 0)
            {
                switch (Recuperation)
                {
                    case 1:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 2:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 3:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 4:
                        CoutPouvoir.PP = 40;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 5:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 4;
                        break;
                }
            }
            if (DestArmure != 0)
            {
                switch (DestArmure)
                {
                    case 1:
                        CoutPouvoir.PP = 40;
                        CoutPouvoir.Niveau = 1;
                        break;
                    case 2:
                        CoutPouvoir.PP = 20;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 3:
                        CoutPouvoir.PP = 40;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 4:
                        CoutPouvoir.PP = 120;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 5:
                        CoutPouvoir.PP = 20;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 6:
                        CoutPouvoir.PP = 40;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 7:
                        CoutPouvoir.PP = 20;
                        CoutPouvoir.Niveau = 4;
                        break;
                    case 8:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 4;
                        break;
                }
            }
            if (Element != 0)
            {
                switch (Element)
                {
                    case 1:
                        CoutPouvoir.PP = 30;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 2:
                        CoutPouvoir.PP = 30;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 3:
                        CoutPouvoir.PP = 30;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 4:
                        CoutPouvoir.PP = 60;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 5:
                        CoutPouvoir.PP = 60;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 6:
                        CoutPouvoir.PP = 20;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 7:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 1;
                        break;
                }
                if (ElemVariable)
                {
                    CoutPouvoir.PP += 20;
                }
                if (ElemCombine)
                {
                    CoutPouvoir.PP += 40;
                }
                if (ElemPrime)
                {
                    CoutPouvoir.PP += 50;
                }
            }
            if (Enchantee != 0)
            {
                switch (Enchantee)
                {
                    case 1:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 2:
                        CoutPouvoir.PP = 80;
                        CoutPouvoir.Niveau = 3;
                        break;
                }
            }
            if (AutreComp != 0)
            {
                switch (AutreComp)
                {
                    case 1:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 2:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 3:
                        CoutPouvoir.PP = 40;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 4:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 5:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 6:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 3;
                        break;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        public override void ExportXML(XmlWriter writer)
        {
            writer.WriteStartElement("ClassFacetteCombat");

            writer.WriteStartElement("TypePouvoir");
            writer.WriteValue((int)TypePouvoir);
            writer.WriteEndElement();

            writer.WriteStartElement("CoutPouvoir");
            writer.WriteStartElement("PP");
            writer.WriteValue(CoutPouvoir.PP);
            writer.WriteEndElement();
            writer.WriteStartElement("Niveau");
            writer.WriteValue(CoutPouvoir.Niveau);
            writer.WriteEndElement();
            writer.WriteEndElement();

            if (Attaque > 0)
            {
                writer.WriteStartElement("Attaque");
                writer.WriteValue(Attaque);
                writer.WriteEndElement();
            }
            if (Offensif > 0)
            {
                writer.WriteStartElement("Offensif");
                writer.WriteValue(Offensif);
                writer.WriteEndElement();
            }
            if (BonusDegat > 0)
            {
                writer.WriteStartElement("BonusDegat");
                writer.WriteValue(BonusDegat);
                writer.WriteEndElement();
            }
            if (Exterminateur > 0)
            {
                writer.WriteStartElement("Exterminateur");
                writer.WriteValue(Exterminateur);
                writer.WriteElementString("DescExterminateur", DescExterminateur);
                if (GrandExterminateur)
                {
                    writer.WriteStartElement("GrandExterminateur");
                    writer.WriteValue(GrandExterminateur);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            if (Assaut > 0)
            {
                writer.WriteStartElement("Assaut");
                writer.WriteValue(Assaut);
                writer.WriteEndElement();
            }
            if (Munition > 0)
            {
                writer.WriteStartElement("Munition");
                writer.WriteValue(Munition);
                if (Firearm)
                {
                    writer.WriteStartElement("Firearm");
                    writer.WriteValue(Firearm);
                    writer.WriteEndElement();
                }
                if (MuniCombi)
                {
                    writer.WriteStartElement("MuniCombi");
                    writer.WriteValue(MuniCombi);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            if (Critique > 0)
            {
                writer.WriteStartElement("Critique");
                writer.WriteValue(Critique);
                writer.WriteEndElement();
            }
            if (Recuperation > 0)
            {
                writer.WriteStartElement("Recuperation");
                writer.WriteValue(Recuperation);
                writer.WriteEndElement();
            }
            if (DestArmure > 0)
            {
                writer.WriteStartElement("DestArmure");
                writer.WriteValue(DestArmure);
                writer.WriteEndElement();
            }
            if (Enchantee > 0)
            {
                writer.WriteStartElement("Enchantee");
                writer.WriteValue(Enchantee);
                writer.WriteEndElement();
            }
            if (Element > 0)
            {
                writer.WriteStartElement("Element");
                writer.WriteValue(Element);
                if (ElemVariable)
                {
                    writer.WriteStartElement("ElemVariable");
                    writer.WriteValue(ElemVariable);
                    writer.WriteEndElement();
                }
                if (ElemCombine)
                {
                    writer.WriteStartElement("ElemCombine");
                    writer.WriteValue(ElemCombine);
                    writer.WriteEndElement();
                }
                if (ElemPrime)
                {
                    writer.WriteStartElement("ElemPrime");
                    writer.WriteValue(ElemPrime);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            if (AutreComp > 0)
            {
                writer.WriteStartElement("AutreComp");
                writer.WriteValue(AutreComp);
                writer.WriteEndElement();
            }


            writer.WriteEndElement();
        }

        public override string DescriptionPouvoirUneLigne()
        {
            string tempDesc = "";

            if (Attaque != 0)
            {
                tempDesc = "Arme à l'attaque accrue: ";
                switch (Attaque)
                {
                    case 1:
                        tempDesc += "+5.";
                        break;
                    case 2:
                        tempDesc += "+10.";
                        break;
                    case 3:
                        tempDesc += "+15.";
                        break;
                    case 4:
                        tempDesc += "+20.";
                        break;
                    case 5:
                        tempDesc += "+25.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (Offensif != 0)
            {
                tempDesc = "Renforcement offensif: ";
                switch (Offensif)
                {
                    case 1:
                        tempDesc += "+5.";
                        break;
                    case 2:
                        tempDesc += "+10.";
                        break;
                    case 3:
                        tempDesc += "+15.";
                        break;
                    case 4:
                        tempDesc += "+20.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (BonusDegat != 0)
            {
                tempDesc = "Dégâts accrus: ";
                switch (BonusDegat)
                {
                    case 1:
                        tempDesc += "+10.";
                        break;
                    case 2:
                        tempDesc += "+20.";
                        break;
                    case 3:
                        tempDesc += "+30.";
                        break;
                    case 4:
                        tempDesc += "+40.";
                        break;
                    case 5:
                        tempDesc += "+50.";
                        break;
                    case 6:
                        tempDesc += "+60.";
                        break;
                    case 7:
                        tempDesc += "+80.";
                        break;
                    case 8:
                        tempDesc += "+100.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (Exterminateur != 0)
            {
                tempDesc = "Exterminateur: ";
                switch (Exterminateur)
                {
                    case 1:
                        tempDesc += "Un type de race: " + DescExterminateur + ".";
                        break;
                    case 2:
                        tempDesc += "Un être en particulier: " + DescExterminateur + ".";
                        break;
                    case 3:
                        tempDesc += "Une condition: " + DescExterminateur + ".";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (Assaut != 0)
            {
                tempDesc = "Assaut: ";
                switch (Assaut)
                {
                    case 1:
                        tempDesc += "Assaut.";
                        break;
                    case 2:
                        tempDesc += "Assaut majeur.";
                        break;
                    case 3:
                        tempDesc += "Force 8.";
                        break;
                    case 4:
                        tempDesc += "Force 10.";
                        break;
                    case 5:
                        tempDesc += "Force 12.";
                        break;
                    case 6:
                        tempDesc += "Force 15.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (Munition != 0)
            {
                tempDesc = "Munitions illimitées: ";
                switch (Munition)
                {
                    case 1:
                        tempDesc += "10 Projectiles par jour.";
                        break;
                    case 2:
                        tempDesc += "25 Projectiles par jour.";
                        break;
                    case 3:
                        tempDesc += "100 Projectiles par jour.";
                        break;
                    case 4:
                        tempDesc += "Projectiles infinis.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (Critique != 0)
            {
                tempDesc = "Critique accru: ";
                switch (Critique)
                {
                    case 1:
                        tempDesc += "+10.";
                        break;
                    case 2:
                        tempDesc += "+20.";
                        break;
                    case 3:
                        tempDesc += "+30.";
                        break;
                    case 4:
                        tempDesc += "+40.";
                        break;
                    case 5:
                        tempDesc += "+50.";
                        break;
                    case 6:
                        tempDesc += "+60.";
                        break;
                    case 7:
                        tempDesc += "Critique automatique.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (Recuperation != 0)
            {
                tempDesc = "Récupération: ";
                switch (Recuperation)
                {
                    case 1:
                        tempDesc += "Lancement (actif).";
                        break;
                    case 2:
                        tempDesc += "Lancement (passif).";
                        break;
                    case 3:
                        tempDesc += "À vue.";
                        break;
                    case 4:
                        tempDesc += "À proximité.";
                        break;
                    case 5:
                        tempDesc += "Illimitée.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (DestArmure != 0)
            {
                tempDesc = "Destruction d'armure: ";
                switch (DestArmure)
                {
                    case 1:
                        tempDesc += "IP -1.";
                        break;
                    case 2:
                        tempDesc += "IP -2.";
                        break;
                    case 3:
                        tempDesc += "IP -3.";
                        break;
                    case 4:
                        tempDesc += "IP -4.";
                        break;
                    case 5:
                        tempDesc += "IP -5.";
                        break;
                    case 6:
                        tempDesc += "IP -6.";
                        break;
                    case 7:
                        tempDesc += "IP -8.";
                        break;
                    case 8:
                        tempDesc += "IP ignoré.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (Element != 0)
            {
                tempDesc = "Attaques élémentaires: ";
                switch (Element)
                {
                    case 1:
                        tempDesc += "Froid.";
                        break;
                    case 2:
                        tempDesc += "Feu.";
                        break;
                    case 3:
                        tempDesc += "Électricité.";
                        break;
                    case 4:
                        tempDesc += "Lumière.";
                        break;
                    case 5:
                        tempDesc += "Obscurité.";
                        break;
                    case 6:
                        tempDesc += "Énergie.";
                        break;
                    case 7:
                        tempDesc += "Terre(PER) ou vent(TRA) ou eau(CON).";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (Enchantee != 0)
            {
                tempDesc = "Enchantée: ";
                switch (Enchantee)
                {
                    case 1:
                        tempDesc += "Enchantée.";
                        break;
                    case 2:
                        tempDesc += "Surnaturelle.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (AutreComp != 0)
            {
                tempDesc = "Autre compétences d'armes: ";
                switch (AutreComp)
                {
                    case 1:
                        tempDesc += "Précise.";
                        break;
                    case 2:
                        tempDesc += "Vorpale.";
                        break;
                    case 3:
                        tempDesc += "Mode variable.";
                        break;
                    case 4:
                        tempDesc += "Transformation(limitée).";
                        break;
                    case 5:
                        tempDesc += "Transformation(complète).";
                        break;
                    case 6:
                        tempDesc += "Contrôle des dégâts.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            return tempDesc;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ClassAttaqueSpec : ClassFacette
    {
        /// <summary>
        /// index 0 = melee, 1 = 25m,  2 = 50m, 3 = 100m, 4 = 250m, 5 = 1km, 6 = tout point visible
        /// </summary>
        public int Distance { get; set; }
        /// <summary>
        /// index 0 = 1/2 base, 1 = 40, 2 = 60, 3 = 80, 4 = 100, 5 = 120, 6 = 150, 7 = 200, 8 = 250, 9 = base
        /// </summary>
        public int Degat { get; set; }
        /// <summary>
        /// index 0 = non, 1 = 1m, 2 = 3m, 3 = 5m, 4 = 10m, 5 = 25m, 6 = 100m, 7 = 250m, 8 = 500m //(radius pour tous)
        /// </summary>
        public int Zone { get; set; }
        /// <summary>
        /// index 0 = non, 1  = 80, 2 = 120, 3 = 180, 4 = 240, 5 = 320, 6 = 440
        /// </summary>
        public int CompOff { get; set; }
        /// <summary>
        /// nb 0-10 round de prep
        /// </summary>
        public int Prep { get; set; }
        /// <summary>
        /// index 0 = ilimité, 1 = 1/jour, 2 = 3/jour, 3 = 5/jour
        /// </summary>
        public int NbJour { get; set; }
        /// <summary>
        /// modificateur de compétence offensive
        /// </summary>
        public bool ResFinal { get; set; }
        /// <summary>
        /// le nom de l'attaque ;)
        /// </summary>
        public string nom { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ClassAttaqueSpec()
        {
            //initialization des variables
            TypePouvoir = TypeFacette.FacetteCombat;
            SubType = SubTypeFacette.AttaqueSpeciale;
            Distance = 0;
            Degat = 0;
            Zone = 0;
            CompOff = 0;
            Prep = 0;
            NbJour = 0;
            ResFinal = false;
            nom = "";

            CoutPouvoir = new ClassCoutPouvoir(0, 0, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override void DescriptionPouvoir(List<string> description)
        {
            string tempDesc = "";
            description.Add("Attaque spéciale: " + nom + ".");
            if (Distance != 0)
            {
                tempDesc = "Distance: ";
                switch (Distance)
                {
                    case 1:
                        tempDesc += "25 mètres.";
                        break;
                    case 2:
                        tempDesc += "50 mètres.";
                        break;
                    case 3:
                        tempDesc += "100 mètres.";
                        break;
                    case 4:
                        tempDesc += "250 mètres.";
                        break;
                    case 5:
                        tempDesc += "1 kilomètres.";
                        break;
                    case 6:
                        tempDesc += "Tout point visible.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
                description.Add(tempDesc);
            }
            if (Degat != 0)
            {
                tempDesc = "Dégâts: ";
                switch (Degat)
                {
                    case 1:
                        tempDesc += "Dégâts 40.";
                        break;
                    case 2:
                        tempDesc += "Dégâts 60.";
                        break;
                    case 3:
                        tempDesc += "Dégâts 80.";
                        break;
                    case 4:
                        tempDesc += "Dégâts 100.";
                        break;
                    case 5:
                        tempDesc += "Dégâts 120.";
                        break;
                    case 6:
                        tempDesc += "Dégâts 150.";
                        break;
                    case 7:
                        tempDesc += "Dégâts 200.";
                        break;
                    case 8:
                        tempDesc += "Dégâts 250.";
                        break;
                    case 9:
                        tempDesc += "Dégâts complets.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
                description.Add(tempDesc);
            }
            if (Zone != 0)
            {
                tempDesc = "Zone: ";
                switch (Zone)
                {
                    case 1:
                        tempDesc += "Rayon de 1 mètre.";
                        break;
                    case 2:
                        tempDesc += "Rayon de 3 mètres.";
                        break;
                    case 3:
                        tempDesc += "Rayon de 5 mètres.";
                        break;
                    case 4:
                        tempDesc += "Rayon de 10 mètres.";
                        break;
                    case 5:
                        tempDesc += "Rayon de 25 mètres.";
                        break;
                    case 6:
                        tempDesc += "Rayon de 100 mètres.";
                        break;
                    case 7:
                        tempDesc += "Rayon de 250 mètres.";
                        break;
                    case 8:
                        tempDesc += "Rayon de 500 mètres.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
                description.Add(tempDesc);
            }
            if (CompOff != 0)
            {
                tempDesc = "Compétence offensinve: ";
                switch (CompOff)
                {
                    case 1:
                        tempDesc += "80.";
                        break;
                    case 2:
                        tempDesc += "120.";
                        break;
                    case 3:
                        tempDesc += "140.";
                        break;
                    case 4:
                        tempDesc += "1800.";
                        break;
                    case 5:
                        tempDesc += "240.";
                        break;
                    case 6:
                        tempDesc += "320.";
                        break;
                    case 7:
                        tempDesc += "440.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
                description.Add(tempDesc);
                if (ResFinal)
                {
                    tempDesc = "   Résultats final.";
                    description.Add(tempDesc);
                }
            }
            if (Prep == 0)
            {
                tempDesc = "Préparation: Instant.";
                description.Add(tempDesc);
            }
            else if (Prep <= 10)
            {
                tempDesc = "Préparation: " + Prep + ".";
                description.Add(tempDesc);
            }
            else
            {
                tempDesc = "Préparation: Bonus hors norme.";
                description.Add(tempDesc);
            }

            tempDesc = "Utilisation(s): ";
            if (NbJour == 0)
            {
                tempDesc += "Illimitées.";
            }
            else
            {
                switch (NbJour)
                {
                    case 1:
                        tempDesc += "1 par jour.";
                        break;
                    case 2:
                        tempDesc += "3 par jour.";
                        break;
                    case 3:
                        tempDesc += "5 par jour.";
                        break;
                    default:
                        tempDesc += "Bonus hors norme.";
                        break;

                }
            }
            description.Add(tempDesc);

            description.Add("PP: " + CoutPouvoir.PP + " niveau : " + CoutPouvoir.Niveau);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override void GenererCoutPouvoir()
        {
            CoutPouvoir = new ClassCoutPouvoir(0, 0);
            
            if (Distance != 0)
            {
                switch (Distance)
                {
                    case 1:
                        CoutPouvoir.PP += 20;
                        if (CoutPouvoir.Niveau < 2)
                            CoutPouvoir.Niveau = 2;
                        break;
                    case 2:
                        CoutPouvoir.PP += 40;
                        if (CoutPouvoir.Niveau < 2)
                            CoutPouvoir.Niveau = 2;
                        break;
                    case 3:
                        CoutPouvoir.PP += 80;
                        if (CoutPouvoir.Niveau < 2)
                            CoutPouvoir.Niveau = 2;
                        break;
                    case 4:
                        CoutPouvoir.PP += 40;
                        if (CoutPouvoir.Niveau < 3)
                            CoutPouvoir.Niveau = 3;
                        break;
                    case 5:
                        CoutPouvoir.PP += 40;
                        if (CoutPouvoir.Niveau < 4)
                            CoutPouvoir.Niveau = 4;
                        break;
                    case 6:
                        CoutPouvoir.PP += 80;
                        if (CoutPouvoir.Niveau < 4)
                            CoutPouvoir.Niveau = 4;
                        break;
                }
            }
            if (Degat != 0)
            {
                switch (Degat)
                {
                    case 1:
                        CoutPouvoir.PP += 10;
                        if (CoutPouvoir.Niveau < 2)
                            CoutPouvoir.Niveau = 2;
                        break;
                    case 2:
                        CoutPouvoir.PP += 40;
                        if (CoutPouvoir.Niveau < 2)
                            CoutPouvoir.Niveau = 2;
                        break;
                    case 3:
                        CoutPouvoir.PP += 10;
                        if (CoutPouvoir.Niveau < 3)
                            CoutPouvoir.Niveau = 3;
                        break;
                    case 4:
                        CoutPouvoir.PP += 20;
                        if (CoutPouvoir.Niveau < 3)
                            CoutPouvoir.Niveau = 3;
                        break;
                    case 5:
                        CoutPouvoir.PP += 40;
                        if (CoutPouvoir.Niveau < 3)
                            CoutPouvoir.Niveau = 3;
                        break;
                    case 6:
                        CoutPouvoir.PP += 20;
                        if (CoutPouvoir.Niveau < 4)
                            CoutPouvoir.Niveau = 4;
                        break;
                    case 7:
                        CoutPouvoir.PP += 40;
                        if (CoutPouvoir.Niveau < 4)
                            CoutPouvoir.Niveau = 4;
                        break;
                    case 8:
                        CoutPouvoir.PP += 80;
                        if (CoutPouvoir.Niveau < 4)
                            CoutPouvoir.Niveau = 4;
                        break;
                    case 9:
                        CoutPouvoir.PP += 80;
                        if (CoutPouvoir.Niveau < 2)
                            CoutPouvoir.Niveau = 2;
                        break;
                }
            }
            if (Zone != 0)
            {
                switch (Zone)
                {
                    case 1:
                        CoutPouvoir.PP += 20;
                        if (CoutPouvoir.Niveau < 2)
                            CoutPouvoir.Niveau = 2;
                        break;
                    case 2:
                        CoutPouvoir.PP += 40;
                        if (CoutPouvoir.Niveau < 2)
                            CoutPouvoir.Niveau = 2;
                        break;
                    case 3:
                        CoutPouvoir.PP += 80;
                        if (CoutPouvoir.Niveau < 2)
                            CoutPouvoir.Niveau = 2;
                        break;
                    case 4:
                        CoutPouvoir.PP += 20;
                        if (CoutPouvoir.Niveau < 3)
                            CoutPouvoir.Niveau = 3;
                        break;
                    case 5:
                        CoutPouvoir.PP += 40;
                        if (CoutPouvoir.Niveau < 3)
                            CoutPouvoir.Niveau = 3;
                        break;
                    case 6:
                        CoutPouvoir.PP += 40;
                        if (CoutPouvoir.Niveau < 4)
                            CoutPouvoir.Niveau = 4;
                        break;
                    case 7:
                        CoutPouvoir.PP += 80;
                        if (CoutPouvoir.Niveau < 4)
                            CoutPouvoir.Niveau = 4;
                        break;
                    case 8:
                        CoutPouvoir.PP += 40;
                        if (CoutPouvoir.Niveau < 5)
                            CoutPouvoir.Niveau = 5;
                        break;
                }
            }
            if (CompOff != 0)
            {
                switch (CompOff)
                {
                    case 1:
                        CoutPouvoir.PP += 100;
                        if (CoutPouvoir.Niveau < 2)
                            CoutPouvoir.Niveau = 2;
                        break;
                    case 2:
                        CoutPouvoir.PP += 150;
                        if (CoutPouvoir.Niveau < 2)
                            CoutPouvoir.Niveau = 2;
                        break;
                    case 3:
                        CoutPouvoir.PP += 250;
                        if (CoutPouvoir.Niveau < 2)
                            CoutPouvoir.Niveau = 2;
                        break;
                    case 4:
                        CoutPouvoir.PP += 100;
                        if (CoutPouvoir.Niveau < 3)
                            CoutPouvoir.Niveau = 3;
                        break;
                    case 5:
                        CoutPouvoir.PP += 200;
                        if (CoutPouvoir.Niveau < 3)
                            CoutPouvoir.Niveau = 3;
                        break;
                    case 6:
                        CoutPouvoir.PP += 100;
                        if (CoutPouvoir.Niveau < 4)
                            CoutPouvoir.Niveau = 4;
                        break;
                    case 7:
                        CoutPouvoir.PP += 100;
                        if (CoutPouvoir.Niveau < 5)
                            CoutPouvoir.Niveau = 5;
                        break;
                }
            }
            if (Prep != 0)
            {
                switch (Prep)
                {
                    case 1:
                        CoutPouvoir.PP -= 5;
                        break;
                    case 2:
                        CoutPouvoir.PP -= 10;
                        break;
                    case 3:
                        CoutPouvoir.PP -= 15;
                        break;
                    case 4:
                        CoutPouvoir.PP -= 20;
                        break;
                    case 5:
                        CoutPouvoir.PP -= 25;
                        break;
                    case 6:
                        CoutPouvoir.PP -= 30;
                        break;
                    case 7:
                        CoutPouvoir.PP -= 35;
                        break;
                    case 8:
                        CoutPouvoir.PP -= 40;
                        break;
                    case 9:
                        CoutPouvoir.PP -= 45;
                        break;
                    case 10:
                        CoutPouvoir.PP -= 50;
                        break;
                }
            }
            if (NbJour != 0)
            {
                switch (NbJour)
                {
                    case 1:
                        CoutPouvoir.PP -= 40;
                        break;
                    case 2:
                        CoutPouvoir.PP -= 20;
                        break;
                    case 3:
                        CoutPouvoir.PP -= 10;
                        break;
                }
            }
            if (ResFinal)
            {
                CoutPouvoir.PP -= 40;
            }

            if (CoutPouvoir.PP < 0)
            {
                CoutPouvoir.Niveau = 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        public override void ExportXML(XmlWriter writer)
        {
            writer.WriteStartElement("ClassAttaqueSpec");

            writer.WriteElementString("nom", nom);

            writer.WriteStartElement("TypePouvoir");
            writer.WriteValue((int)TypePouvoir);
            writer.WriteEndElement();

            writer.WriteStartElement("CoutPouvoir");
            writer.WriteStartElement("PP");
            writer.WriteValue(CoutPouvoir.PP);
            writer.WriteEndElement();
            writer.WriteStartElement("Niveau");
            writer.WriteValue(CoutPouvoir.Niveau);
            writer.WriteEndElement();
            writer.WriteEndElement();
            
            if (Distance > 0)
            {
                writer.WriteStartElement("Distance");
                writer.WriteValue(Distance);
                writer.WriteEndElement();
            }
            if (Degat > 0)
            {
                writer.WriteStartElement("Degat");
                writer.WriteValue(Degat);
                writer.WriteEndElement();
            }
            if (Zone > 0)
            {
                writer.WriteStartElement("Zone");
                writer.WriteValue(Zone);
                writer.WriteEndElement();
            }
            if (Prep > 0)
            {
                writer.WriteStartElement("Prep");
                writer.WriteValue(Prep);
                writer.WriteEndElement();
            }
            if (NbJour > 0)
            {
                writer.WriteStartElement("NbJour");
                writer.WriteValue(NbJour);
                writer.WriteEndElement();
            }
            if (CompOff > 0)
            {
                writer.WriteStartElement("CompOff");
                writer.WriteValue(CompOff);
                writer.WriteEndElement();
                if (ResFinal)
                {
                    writer.WriteStartElement("ResFinal");
                    writer.WriteValue(ResFinal);
                    writer.WriteEndElement();
                }
            }
            writer.WriteEndElement();
        }

        public override string DescriptionPouvoirUneLigne()
        {
            string tempDesc = "";
            tempDesc = "Attaque spéciale: " + nom;
            if (Distance != 0)
            {
                tempDesc += ", Distance: ";
                switch (Distance)
                {
                    case 1:
                        tempDesc += "25 mètres.";
                        break;
                    case 2:
                        tempDesc += "50 mètres.";
                        break;
                    case 3:
                        tempDesc += "100 mètres.";
                        break;
                    case 4:
                        tempDesc += "250 mètres.";
                        break;
                    case 5:
                        tempDesc += "1 kilomètres.";
                        break;
                    case 6:
                        tempDesc += "Tout point visible.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            if (Degat != 0)
            {
                tempDesc += ", Dégâts: ";
                switch (Degat)
                {
                    case 1:
                        tempDesc += "Dégâts 40.";
                        break;
                    case 2:
                        tempDesc += "Dégâts 60.";
                        break;
                    case 3:
                        tempDesc += "Dégâts 80.";
                        break;
                    case 4:
                        tempDesc += "Dégâts 100.";
                        break;
                    case 5:
                        tempDesc += "Dégâts 120.";
                        break;
                    case 6:
                        tempDesc += "Dégâts 150.";
                        break;
                    case 7:
                        tempDesc += "Dégâts 200.";
                        break;
                    case 8:
                        tempDesc += "Dégâts 250.";
                        break;
                    case 9:
                        tempDesc += "Dégâts complets.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            if (Zone != 0)
            {
                tempDesc = ", Zone: ";
                switch (Zone)
                {
                    case 1:
                        tempDesc += "Rayon de 1 mètre.";
                        break;
                    case 2:
                        tempDesc += "Rayon de 3 mètres.";
                        break;
                    case 3:
                        tempDesc += "Rayon de 5 mètres.";
                        break;
                    case 4:
                        tempDesc += "Rayon de 10 mètres.";
                        break;
                    case 5:
                        tempDesc += "Rayon de 25 mètres.";
                        break;
                    case 6:
                        tempDesc += "Rayon de 100 mètres.";
                        break;
                    case 7:
                        tempDesc += "Rayon de 250 mètres.";
                        break;
                    case 8:
                        tempDesc += "Rayon de 500 mètres.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            if (CompOff != 0)
            {
                tempDesc = ", Compétence offensinve: ";
                switch (CompOff)
                {
                    case 1:
                        tempDesc += "80.";
                        break;
                    case 2:
                        tempDesc += "120.";
                        break;
                    case 3:
                        tempDesc += "140.";
                        break;
                    case 4:
                        tempDesc += "1800.";
                        break;
                    case 5:
                        tempDesc += "240.";
                        break;
                    case 6:
                        tempDesc += "320.";
                        break;
                    case 7:
                        tempDesc += "440.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            return tempDesc;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ClassFacetteDefensive : ClassFacette
    {
        /// <summary>
        /// index 0 = 0, 1 = +5, 2 = +10, 3 = +15, 4 = +20, 5 = +25
        /// </summary>
        public int QualiteArmure { get; set; }
        /// <summary>
        /// Si il y a une ouverture dans l'armure
        /// </summary>
        public bool Ouverture { get; set; }
        /// <summary>
        /// index de 0 à 6
        /// </summary>
        public int ArmureInnee { get; set; }
        /// <summary>
        /// index 0 = TRA, 2 = CON, 3 = PER, 4 = CHA, 5 = FRO, 6 = ELE, 7 = ENE
        /// </summary>
        public int TypeArmure { get; set; }
        /// <summary>
        /// index 0 = NONE, 1 = Physique, 2 = Élémentaire, 3 = Concentrée, 4 = Complète
        /// </summary>
        public bool ArmureConcentre { get; set; }
        /// <summary>
        /// Si on peu selectionner le type ENE
        /// </summary>
        public bool ArmureComplete { get; set; }
        /// <summary>
        /// index 0 = 0, 1 = +5, 2 = +10, 3 = +15, 4 = +20
        /// </summary>
        public int RenforcementDef { get; set; }
        /// <summary>
        /// index 0 = 0, 1 = +5, 2 = +10, 3 = +15, 4 = +20, 5 = +25
        /// </summary>
        public int ArmeDefAccrue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ClassFacetteDefensive()
        {
            TypePouvoir = TypeFacette.FacetteDefensive;
            QualiteArmure = 0;
            Ouverture = false;
            ArmureInnee = 0;
            TypeArmure = 0;
            ArmureConcentre = false;
            ArmureComplete = false;
            RenforcementDef = 0;
            ArmeDefAccrue = 0;

            CoutPouvoir = new ClassCoutPouvoir(0, 0, 0);
        }

        public override void DescriptionPouvoir(List<string> description)
        {
            string tempDesc = "Aucun bonus";

            if (QualiteArmure != 0)
            {
                tempDesc = "Bonus de qualité d'armure de +";
                switch (QualiteArmure)
                {
                    case 1:
                        tempDesc += "5.";
                        break;
                    case 2:
                        tempDesc += "10.";
                        break;
                    case 3:
                        tempDesc += "15.";
                        break;
                    case 4:
                        tempDesc += "20.";
                        break;
                    case 5:
                        tempDesc += "25.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme";
                        break;
                }
                if (Ouverture)
                {
                    description.Add(tempDesc);
                    tempDesc = "     Ouverture.";
                }
            }
            else if (ArmureInnee != 0)
            {
                tempDesc = "Bonus d'armure innée: " + ArmureInnee + " ";
                switch (TypeArmure)
                {
                    case 0:
                        tempDesc += "TRA";
                        break;
                    case 1:
                        tempDesc += "CON";
                        break;
                    case 2:
                        tempDesc += "PER";
                        break;
                    case 3:
                        tempDesc += "CHA";
                        break;
                    case 4:
                        tempDesc += "FRO";
                        break;
                    case 5:
                        tempDesc += "ELE";
                        break;
                    case 6:
                        tempDesc += "Physique";
                        break;
                    case 7:
                        tempDesc += "Élémentaire";
                        break;
                    case 8:
                        tempDesc += "Mystique";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
                if (ArmureConcentre)
                {
                    description.Add(tempDesc);
                    tempDesc = "     Concentrée.";
                }
                else if (ArmureComplete)
                {
                    description.Add(tempDesc);
                    tempDesc = "     Complète.";
                }
            }
            else if (RenforcementDef != 0)
            {
                tempDesc = "Renforcement défensif de +";
                switch (RenforcementDef)
                {
                    case 1:
                        tempDesc += "5.";
                        break;
                    case 2:
                        tempDesc += "10.";
                        break;
                    case 3:
                        tempDesc += "15.";
                        break;
                    case 4:
                        tempDesc += "20.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme";
                        break;
                }
            }
            else if (ArmeDefAccrue != 0)
            {
                tempDesc = "Arme avec une défense accue de +";
                switch (ArmeDefAccrue)
                {
                    case 1:
                        tempDesc += "5.";
                        break;
                    case 2:
                        tempDesc += "10.";
                        break;
                    case 3:
                        tempDesc += "15.";
                        break;
                    case 4:
                        tempDesc += "20.";
                        break;
                    case 5:
                        tempDesc += "25.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme";
                        break;
                }
            }
            description.Add(tempDesc);

            tempDesc = "PP: " + CoutPouvoir.PP + " Niveau: " + CoutPouvoir.Niveau + " Presence: " + CoutPouvoir.Presence + ".";
            description.Add(tempDesc);
        }

        public override void ExportXML(XmlWriter writer)
        {
            writer.WriteStartElement("ClassFacetteDefensive");

            writer.WriteStartElement("TypePouvoir");
            writer.WriteValue((int)TypePouvoir);
            writer.WriteEndElement();

            writer.WriteStartElement("CoutPouvoir");
            writer.WriteStartElement("PP");
            writer.WriteValue(CoutPouvoir.PP);
            writer.WriteEndElement();
            writer.WriteStartElement("Niveau");
            writer.WriteValue(CoutPouvoir.Niveau);
            writer.WriteEndElement();
            writer.WriteEndElement();

            if (QualiteArmure > 0)
            {
                writer.WriteStartElement("QualiteArmure");
                writer.WriteValue(QualiteArmure);
                writer.WriteEndElement();
                if (Ouverture)
                {
                    writer.WriteStartElement("Ouverture");
                    writer.WriteValue(Ouverture);
                    writer.WriteEndElement();
                }
            }
            else if (ArmureInnee > 0)
            {
                writer.WriteStartElement("ArmureInnee");
                writer.WriteValue(ArmureInnee);
                writer.WriteEndElement();
                writer.WriteStartElement("TypeArmure");
                writer.WriteValue(TypeArmure);
                writer.WriteEndElement();
                if (ArmureComplete)
                {
                    writer.WriteStartElement("ArmureComplete");
                    writer.WriteValue(ArmureComplete);
                    writer.WriteEndElement();
                }
                if (ArmureConcentre)
                {
                    writer.WriteStartElement("ArmureConcentre");
                    writer.WriteValue(ArmureConcentre);
                    writer.WriteEndElement();
                }
            }
            else if (RenforcementDef > 0)
            {
                writer.WriteStartElement("RenforcementDef");
                writer.WriteValue(RenforcementDef);
                writer.WriteEndElement();
            }
            else if (ArmeDefAccrue > 0)
            {
                writer.WriteStartElement("ArmeDefAccrue");
                writer.WriteValue(ArmeDefAccrue);
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
        }

        public override void GenererCoutPouvoir()
        {
            CoutPouvoir = new ClassCoutPouvoir(0, 0, 0);

            if (QualiteArmure != 0)
            {
                switch (QualiteArmure)
                {
                    case 1:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 2:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 3:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 4:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 4;
                        break;
                    case 5:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 5;
                        break;
                    default:
                        break;
                }
                if (Ouverture)
                {
                    CoutPouvoir.PP -= 10;
                }
            }
            else if (ArmureInnee != 0)
            {
                switch (ArmureInnee)
                {
                    case 1:
                        CoutPouvoir.PP = 40;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 2:
                        CoutPouvoir.PP = 80;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 3:
                        CoutPouvoir.PP = 40;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 4:
                        CoutPouvoir.PP = 80;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 5:
                        CoutPouvoir.PP = 120;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 6:
                        CoutPouvoir.PP = 40;
                        CoutPouvoir.Niveau = 4;
                        break;
                    default:
                        break;
                }
                switch (TypeArmure)
                {
                    case 6:
                    case 7:
                        CoutPouvoir.PP += 80;
                        break;
                    case 8:
                        CoutPouvoir.PP += 40;
                        break;
                    default:
                        break;
                }
                if (ArmureComplete)
                {
                    CoutPouvoir.PP += 20;
                    CoutPouvoir.Niveau += 1;
                }
                if (ArmureConcentre)
                {
                    CoutPouvoir.PP += 80;
                }
            }
            else if (RenforcementDef != 0)
            {
                switch (RenforcementDef)
                {
                    case 1:
                        CoutPouvoir.PP = 60;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 2:
                        CoutPouvoir.PP = 120;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 3:
                        CoutPouvoir.PP = 60;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 4:
                        CoutPouvoir.PP = 60;
                        CoutPouvoir.Niveau = 4;
                        break;
                    default:
                        break;
                }
            }
            else if (ArmeDefAccrue != 0)
            {
                switch (ArmeDefAccrue)
                {
                    case 1:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 1;
                        break;
                    case 2:
                        CoutPouvoir.PP = 20;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 3:
                        CoutPouvoir.PP = 20;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 4:
                        CoutPouvoir.PP = 20;
                        CoutPouvoir.Niveau = 4;
                        break;
                    case 5:
                        CoutPouvoir.PP = 10;
                        CoutPouvoir.Niveau = 5;
                        break;
                    default:
                        break;
                }
            }
        }

        public override string DescriptionPouvoirUneLigne()
        {
            string tempDesc = "Aucun bonus";

            if (QualiteArmure != 0)
            {
                tempDesc = "Bonus de qualité d'armure de +";
                switch (QualiteArmure)
                {
                    case 1:
                        tempDesc += "5.";
                        break;
                    case 2:
                        tempDesc += "10.";
                        break;
                    case 3:
                        tempDesc += "15.";
                        break;
                    case 4:
                        tempDesc += "20.";
                        break;
                    case 5:
                        tempDesc += "25.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme";
                        break;
                }
            }
            else if (ArmureInnee != 0)
            {
                tempDesc = "Bonus d'armure innée: " + ArmureInnee + " ";
                switch (TypeArmure)
                {
                    case 0:
                        tempDesc += "TRA";
                        break;
                    case 1:
                        tempDesc += "CON";
                        break;
                    case 2:
                        tempDesc += "PER";
                        break;
                    case 3:
                        tempDesc += "CHA";
                        break;
                    case 4:
                        tempDesc += "FRO";
                        break;
                    case 5:
                        tempDesc += "ELE";
                        break;
                    case 6:
                        tempDesc += "Physique";
                        break;
                    case 7:
                        tempDesc += "Élémentaire";
                        break;
                    case 8:
                        tempDesc += "Mystique";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (RenforcementDef != 0)
            {
                tempDesc = "Renforcement défensif de +";
                switch (RenforcementDef)
                {
                    case 1:
                        tempDesc += "5.";
                        break;
                    case 2:
                        tempDesc += "10.";
                        break;
                    case 3:
                        tempDesc += "15.";
                        break;
                    case 4:
                        tempDesc += "20.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme";
                        break;
                }
            }
            else if (ArmeDefAccrue != 0)
            {
                tempDesc = "Arme avec une défense accue de +";
                switch (ArmeDefAccrue)
                {
                    case 1:
                        tempDesc += "5.";
                        break;
                    case 2:
                        tempDesc += "10.";
                        break;
                    case 3:
                        tempDesc += "15.";
                        break;
                    case 4:
                        tempDesc += "20.";
                        break;
                    case 5:
                        tempDesc += "25.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme";
                        break;
                }
            }
            return tempDesc;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ClassFacetteProtection : ClassFacette
    {
        public int Immunite;
        public int ImmuniteMagique;
        public int ImmunitePsychique;
        public int ImmuniteElementaire;
        public int ReductionDegat;
        public int SeuilInvul;
        public int AugmentRes;
        public bool Limite;
        public int VoieDisciplineElement;
        public string TypeAtt;
        public int TypeResistance;
        public bool TypeMagieUnique;
        public bool TypePsyUnique;

        public ClassFacetteProtection()
        {
            TypePouvoir = TypeFacette.FacetteProtection;

            Immunite = 0;
            ImmuniteMagique = 0;
            ImmunitePsychique = 0;
            ImmuniteElementaire = 0;
            ReductionDegat = 0;
            SeuilInvul = 0;
            AugmentRes = 0;
            Limite = false;
            VoieDisciplineElement = 0;
            TypeAtt = "";
            TypeResistance = 0;
            TypeMagieUnique = false;
            TypePsyUnique = false;

            CoutPouvoir = new ClassCoutPouvoir(0, 0, 0);
        }

        public override void DescriptionPouvoir(List<string> description)
        {
            string tempDesc = "Aucun bonus";

            if (Immunite != 0)
            {
                tempDesc = "Immunité(s): ";
                switch (Immunite)
                {
                    case 1:
                        tempDesc += "Dégats réduits de moitié.";
                        break;
                    case 2:
                        tempDesc += "Dégats physiques.";
                        break;
                    case 3:
                        tempDesc += "Dégats mystique réduits de moitié.";
                        break;
                    case 4:
                        tempDesc += "N'importe quelle Présence.";
                        break;
                    case 5:
                        tempDesc += "Présence supérieur à 80.";
                        break;
                    case 6:
                        tempDesc += "Présence supérieur à 120.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme";
                        break;
                }
            }
            else if (ImmuniteMagique != 0)
            {
                tempDesc = "Immunité magique: ";
                switch (ImmuniteMagique)
                {
                    case 1:
                        tempDesc += "Zéon 40.";
                        break;
                    case 2:
                        tempDesc += "Zéon 80.";
                        break;
                    case 3:
                        tempDesc += "Zéon 120.";
                        break;
                    case 4:
                        tempDesc += "Zéon 180.";
                        break;
                    case 5:
                        tempDesc += "Zéon 250.";
                        break;
                    case 6:
                        tempDesc += "Zéon 350.";
                        break;
                    case 7:
                        tempDesc += "Zéon 500.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
                if (Limite)
                {
                    description.Add(tempDesc);
                    tempDesc = "     Voie unique: ";
                    switch (VoieDisciplineElement)
                    {
                        case 1:
                            tempDesc += "Livre de Lumière.";
                            break;
                        case 2:
                            tempDesc += "Livre d'Obscurité.";
                            break;
                        case 3:
                            tempDesc += "Livre de Création.";
                            break;
                        case 4:
                            tempDesc += "Livre de Destruction.";
                            break;
                        case 5:
                            tempDesc += "Livre d'Air.";
                            break;
                        case 6:
                            tempDesc += "Livre d'Eau.";
                            break;
                        case 7:
                            tempDesc += "Livre de Feu.";
                            break;
                        case 8:
                            tempDesc += "Livre de Terre.";
                            break;
                        case 9:
                            tempDesc += "Livre d'Essence.";
                            break;
                        case 10:
                            tempDesc += "Livre d'Illusion.";
                            break;
                        case 11:
                            tempDesc += "Livre de Nécromancie.";
                            break;
                        default:
                            tempDesc += "Livre non défini.";
                            break;
                    }
                }
            }
            else if (ImmunitePsychique != 0)
            {
                tempDesc = "Immunité psychique: ";
                switch (ImmunitePsychique)
                {
                    case 1:
                        tempDesc += "Test de Talent 80.";
                        break;
                    case 2:
                        tempDesc += "Test de Talent 120.";
                        break;
                    case 3:
                        tempDesc += "Test de Talent 140.";
                        break;
                    case 4:
                        tempDesc += "Test de Talent 180.";
                        break;
                    case 5:
                        tempDesc += "Test de Talent 240.";
                        break;
                    case 6:
                        tempDesc += "Test de Talent 280.";
                        break;
                    case 7:
                        tempDesc += "Test de Talent 320.";
                        break;
                    case 8:
                        tempDesc += "Matrices complètes.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme";
                        break;
                }
                if (Limite)
                {
                    description.Add(tempDesc);
                    tempDesc = "     Discipline unique: ";
                    switch (VoieDisciplineElement)
                    {
                        case 1:
                            tempDesc += "Télépathie.";
                            break;
                        case 2:
                            tempDesc += "Télékinésie.";
                            break;
                        case 3:
                            tempDesc += "Pyrokinésie.";
                            break;
                        case 4:
                            tempDesc += "Cryokinésie.";
                            break;
                        case 5:
                            tempDesc += "Augmentation physique.";
                            break;
                        case 6:
                            tempDesc += "Énergie.";
                            break;
                        case 7:
                            tempDesc += "Sensation.";
                            break;
                        case 8:
                            tempDesc += "Télémétrie.";
                            break;
                        case 9:
                            tempDesc += "Causalité.";
                            break;
                        case 10:
                            tempDesc += "Électromagnétisme.";
                            break;
                        case 11:
                            tempDesc += "Téléportation.";
                            break;
                        case 12:
                            tempDesc += "Lumière.";
                            break;
                        case 13:
                            tempDesc += "Hypersensibilité.";
                            break;
                        default:
                            tempDesc += "Discipline non défini.";
                            break;
                    }
                }
            }
            else if (ImmuniteElementaire != 0)
            {
                tempDesc = "Immunité élémentaire: ";
                switch (ImmuniteElementaire)
                {
                    case 1:
                        tempDesc += "2 intensités.";
                        break;
                    case 2:
                        tempDesc += "4 intensités.";
                        break;
                    case 3:
                        tempDesc += "6 intensités.";
                        break;
                    case 4:
                        tempDesc += "10 intensités.";
                        break;
                    case 5:
                        tempDesc += "20 intensités.";
                        break;
                    case 6:
                        tempDesc += "Immunité totale.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme";
                        break;
                }
                description.Add(tempDesc);
                tempDesc = "     Versus ";
                switch (VoieDisciplineElement)
                {
                    case 1:
                        tempDesc += "l'air.";
                        break;
                    case 2:
                        tempDesc += "la terre.";
                        break;
                    case 3:
                        tempDesc += "le feu.";
                        break;
                    case 4:
                        tempDesc += "l'eau.";
                        break;
                    case 5:
                        tempDesc += "la noirceur[Anima].";
                        break;
                    case 6:
                        tempDesc += "la lumière[Anima].";
                        break;
                    case 7:
                        tempDesc += "les éléments naturels.";
                        break;
                    case 8:
                        tempDesc += "tous les éléments.";
                        break;
                    default:
                        tempDesc += "Élément(s) non défini(s).";
                        break;
                }
            }
            else if (ReductionDegat != 0)
            {
                tempDesc = "Réduction des dégats de -";
                switch (ReductionDegat)
                {
                    case 1:
                        tempDesc += "10.";
                        break;
                    case 2:
                        tempDesc += "20.";
                        break;
                    case 3:
                        tempDesc += "30.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme";
                        break;
                }
                description.Add(tempDesc);
                tempDesc = "     Versus " + TypeAtt + ".";
            }
            else if (SeuilInvul != 0)
            {
                tempDesc = "Seuil d'invulnérabilité de ";
                switch (SeuilInvul)
                {
                    case 1:
                        tempDesc += "40.";
                        break;
                    case 2:
                        tempDesc += "60.";
                        break;
                    case 3:
                        tempDesc += "80.";
                        break;
                    case 4:
                        tempDesc += "10.";
                        break;
                    case 5:
                        tempDesc += "120.";
                        break;
                    case 6:
                        tempDesc += "150.";
                        break;
                    case 7:
                        tempDesc += "180.";
                        break;
                    case 8:
                        tempDesc += "250.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme";
                        break;
                }
            }
            else if (AugmentRes != 0)
            {
                tempDesc = "Amélioration des résistances, bonus de +";
                switch (AugmentRes)
                {
                    case 1:
                        tempDesc += "10.";
                        break;
                    case 2:
                        tempDesc += "20.";
                        break;
                    case 3:
                        tempDesc += "30.";
                        break;
                    case 4:
                        tempDesc += "40.";
                        break;
                    case 5:
                        tempDesc += "50.";
                        break;
                    case 6:
                        tempDesc += "80.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme";
                        break;
                }
                description.Add(tempDesc);
                tempDesc = "     Versus ";
                switch (VoieDisciplineElement)
                {
                    case 1:
                        tempDesc += "RPhy.";
                        break;
                    case 2:
                        tempDesc += "RPoi.";
                        break;
                    case 3:
                        tempDesc += "RMal.";
                        break;
                    case 4:
                        tempDesc += "RMys.";
                        if (Limite)
                        {
                            description.Add(tempDesc);
                            tempDesc = "     Face au ";
                            switch (VoieDisciplineElement)
                            {
                                case 1:
                                    tempDesc += "Livre de Lumière.";
                                    break;
                                case 2:
                                    tempDesc += "Livre d'Obscurité.";
                                    break;
                                case 3:
                                    tempDesc += "Livre de Création.";
                                    break;
                                case 4:
                                    tempDesc += "Livre de Destruction.";
                                    break;
                                case 5:
                                    tempDesc += "Livre d'Air.";
                                    break;
                                case 6:
                                    tempDesc += "Livre d'Eau.";
                                    break;
                                case 7:
                                    tempDesc += "Livre de Feu.";
                                    break;
                                case 8:
                                    tempDesc += "Livre de Terre.";
                                    break;
                                case 9:
                                    tempDesc += "Livre d'Essence.";
                                    break;
                                case 10:
                                    tempDesc += "Livre d'Illusion.";
                                    break;
                                case 11:
                                    tempDesc += "Livre de Nécromancie.";
                                    break;
                                default:
                                    tempDesc += "Livre non défini.";
                                    break;
                            }
                        }
                        break;
                    case 5:
                        tempDesc += "RPsy.";
                        if (Limite)
                        {
                            description.Add(tempDesc);
                            tempDesc = "     Face à la discipline d";
                            switch (VoieDisciplineElement)
                            {
                                case 1:
                                    tempDesc += "e Télépathie.";
                                    break;
                                case 2:
                                    tempDesc += "e Télékinésie.";
                                    break;
                                case 3:
                                    tempDesc += "e Pyrokinésie.";
                                    break;
                                case 4:
                                    tempDesc += "e Cryokinésie.";
                                    break;
                                case 5:
                                    tempDesc += "'Augmentation physique.";
                                    break;
                                case 6:
                                    tempDesc += "'Énergie.";
                                    break;
                                case 7:
                                    tempDesc += "e Sensation.";
                                    break;
                                case 8:
                                    tempDesc += "e Télémétrie.";
                                    break;
                                case 9:
                                    tempDesc += "e Causalité.";
                                    break;
                                case 10:
                                    tempDesc += "'Électromagnétisme.";
                                    break;
                                case 11:
                                    tempDesc += "e Téléportation.";
                                    break;
                                case 12:
                                    tempDesc += "e Lumière.";
                                    break;
                                case 13:
                                    tempDesc += "'Hypersensibilité.";
                                    break;
                                default:
                                    tempDesc += "e Discipline non défini.";
                                    break;
                            }
                        }
                        break;
                    case 6:
                        tempDesc += "résistances de type physique.";
                        break;
                    case 7:
                        tempDesc += "résistances de type mystique.";
                        break;
                    case 8:
                        tempDesc += "toutes les résistances.";
                        break;
                    default:
                        tempDesc += "Élément(s) non défini(s).";
                        break;
                }



            }
            description.Add(tempDesc);

            tempDesc = "PP: " + CoutPouvoir.PP + " Niveau: " + CoutPouvoir.Niveau + " Presence: " + CoutPouvoir.Presence + ".";
            description.Add(tempDesc);
        }

        public override string DescriptionPouvoirUneLigne()
        {
            string tempDesc = "Aucun bonus";

            if (Immunite != 0)
            {
                tempDesc = "Immunité(s): ";
                switch (Immunite)
                {
                    case 1:
                        tempDesc += "Dégats réduits de moitié.";
                        break;
                    case 2:
                        tempDesc += "Dégats physiques.";
                        break;
                    case 3:
                        tempDesc += "Dégats mystique réduits de moitié.";
                        break;
                    case 4:
                        tempDesc += "N'importe quelle Présence.";
                        break;
                    case 5:
                        tempDesc += "Présence supérieur à 80.";
                        break;
                    case 6:
                        tempDesc += "Présence supérieur à 120.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme";
                        break;
                }
            }
            else if (ImmuniteMagique != 0)
            {
                tempDesc = "Immunité magique: ";
                switch (ImmuniteMagique)
                {
                    case 1:
                        tempDesc += "Zéon 40.";
                        break;
                    case 2:
                        tempDesc += "Zéon 80.";
                        break;
                    case 3:
                        tempDesc += "Zéon 120.";
                        break;
                    case 4:
                        tempDesc += "Zéon 180.";
                        break;
                    case 5:
                        tempDesc += "Zéon 250.";
                        break;
                    case 6:
                        tempDesc += "Zéon 350.";
                        break;
                    case 7:
                        tempDesc += "Zéon 500.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (ImmunitePsychique != 0)
            {
                tempDesc = "Immunité psychique: ";
                switch (ImmunitePsychique)
                {
                    case 1:
                        tempDesc += "Test de Talent 80.";
                        break;
                    case 2:
                        tempDesc += "Test de Talent 120.";
                        break;
                    case 3:
                        tempDesc += "Test de Talent 140.";
                        break;
                    case 4:
                        tempDesc += "Test de Talent 180.";
                        break;
                    case 5:
                        tempDesc += "Test de Talent 240.";
                        break;
                    case 6:
                        tempDesc += "Test de Talent 280.";
                        break;
                    case 7:
                        tempDesc += "Test de Talent 320.";
                        break;
                    case 8:
                        tempDesc += "Matrices complètes.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme";
                        break;
                }
            }
            else if (ImmuniteElementaire != 0)
            {
                tempDesc = "Immunité élémentaire: ";
                switch (ImmuniteElementaire)
                {
                    case 1:
                        tempDesc += "2 intensités.";
                        break;
                    case 2:
                        tempDesc += "4 intensités.";
                        break;
                    case 3:
                        tempDesc += "6 intensités.";
                        break;
                    case 4:
                        tempDesc += "10 intensités.";
                        break;
                    case 5:
                        tempDesc += "20 intensités.";
                        break;
                    case 6:
                        tempDesc += "Immunité totale.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme";
                        break;
                }
                tempDesc += " Versus ";
                switch (VoieDisciplineElement)
                {
                    case 1:
                        tempDesc += "l'air.";
                        break;
                    case 2:
                        tempDesc += "la terre.";
                        break;
                    case 3:
                        tempDesc += "le feu.";
                        break;
                    case 4:
                        tempDesc += "l'eau.";
                        break;
                    case 5:
                        tempDesc += "la noirceur[Anima].";
                        break;
                    case 6:
                        tempDesc += "la lumière[Anima].";
                        break;
                    case 7:
                        tempDesc += "les éléments naturels.";
                        break;
                    case 8:
                        tempDesc += "tous les éléments.";
                        break;
                    default:
                        tempDesc += "Élément(s) non défini(s).";
                        break;
                }
            }
            else if (ReductionDegat != 0)
            {
                tempDesc = "Réduction des dégats de -";
                switch (ReductionDegat)
                {
                    case 1:
                        tempDesc += "10.";
                        break;
                    case 2:
                        tempDesc += "20.";
                        break;
                    case 3:
                        tempDesc += "30.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme";
                        break;
                }
                tempDesc += " Versus " + TypeAtt + ".";
            }
            else if (SeuilInvul != 0)
            {
                tempDesc = "Seuil d'invulnérabilité de ";
                switch (SeuilInvul)
                {
                    case 1:
                        tempDesc += "40.";
                        break;
                    case 2:
                        tempDesc += "60.";
                        break;
                    case 3:
                        tempDesc += "80.";
                        break;
                    case 4:
                        tempDesc += "10.";
                        break;
                    case 5:
                        tempDesc += "120.";
                        break;
                    case 6:
                        tempDesc += "150.";
                        break;
                    case 7:
                        tempDesc += "180.";
                        break;
                    case 8:
                        tempDesc += "250.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme";
                        break;
                }
            }
            else if (AugmentRes != 0)
            {
                tempDesc = "Amélioration des résistances, bonus de +";
                switch (AugmentRes)
                {
                    case 1:
                        tempDesc += "10 ";
                        break;
                    case 2:
                        tempDesc += "20 ";
                        break;
                    case 3:
                        tempDesc += "30 ";
                        break;
                    case 4:
                        tempDesc += "40 ";
                        break;
                    case 5:
                        tempDesc += "50 ";
                        break;
                    case 6:
                        tempDesc += "80 ";
                        break;
                    default:
                        tempDesc = "Bonus hors norme ";
                        break;
                }
                switch (VoieDisciplineElement)
                {
                    case 1:
                        tempDesc += "RPhy.";
                        break;
                    case 2:
                        tempDesc += "RPoi.";
                        break;
                    case 3:
                        tempDesc += "RMal.";
                        break;
                    case 4:
                        tempDesc += "RMys.";
                        break;
                    case 5:
                        tempDesc += "RPsy.";
                        break;
                    case 6:
                        tempDesc += "de type physique.";
                        break;
                    case 7:
                        tempDesc += "de type mystique.";
                        break;
                    case 8:
                        tempDesc += " vs toutes les résistances.";
                        break;
                    default:
                        tempDesc += "Élément(s) non défini(s).";
                        break;
                }
            }
            return tempDesc;
        }

        public override void ExportXML(XmlWriter writer)
        {
            throw new NotImplementedException();
        }

        public override void GenererCoutPouvoir()
        {
            CoutPouvoir = new ClassCoutPouvoir(0, 0);

            if (Immunite != 0)
            {
                switch (Immunite)
                {
                    case 1:
                        CoutPouvoir.PP = 140;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 2:
                        CoutPouvoir.PP = 60;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 3:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 4;
                        break;
                    case 4:
                        CoutPouvoir.PP = 80;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 5:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 6:
                        CoutPouvoir.PP = 80;
                        CoutPouvoir.Niveau = 4;
                        break;
                    default:
                        break;
                }
            }
            else if (ImmuniteMagique != 0)
            {
                switch (ImmuniteMagique)
                {
                    case 1:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 2:
                        CoutPouvoir.PP = 250;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 3:
                        CoutPouvoir.PP = 150;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 4:
                        CoutPouvoir.PP = 350;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 5:
                        CoutPouvoir.PP = 150;
                        CoutPouvoir.Niveau = 4;
                        break;
                    case 6:
                        CoutPouvoir.PP = 300;
                        CoutPouvoir.Niveau = 4;
                        break;
                    case 7:
                        CoutPouvoir.PP = 150;
                        CoutPouvoir.Niveau = 5;
                        break;
                    default:
                        break;
                }

                if (Limite)
                {
                    CoutPouvoir.Niveau -= 1;
                }
            }
            else if (ImmunitePsychique != 0)
            {
                switch (ImmunitePsychique)
                {
                    case 1:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 2:
                        CoutPouvoir.PP = 250;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 3:
                        CoutPouvoir.PP = 120;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 4:
                        CoutPouvoir.PP = 300;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 5:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 4;
                        break;
                    case 6:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 4;
                        break;
                    case 7:
                        CoutPouvoir.PP = 250;
                        CoutPouvoir.Niveau = 4;
                        break;
                    case 8:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 5;
                        break;
                    default:
                        break;
                }

                if (Limite)
                {
                    CoutPouvoir.Niveau -= 1;
                }
            }
            else if (ImmunitePsychique != 0)
            {
                switch (ImmunitePsychique)
                {
                    case 1:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 2:
                        CoutPouvoir.PP = 250;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 3:
                        CoutPouvoir.PP = 120;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 4:
                        CoutPouvoir.PP = 300;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 5:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 4;
                        break;
                    case 6:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 4;
                        break;
                    case 7:
                        CoutPouvoir.PP = 250;
                        CoutPouvoir.Niveau = 4;
                        break;
                    case 8:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 5;
                        break;
                    default:
                        break;
                }

                if (Limite)
                {
                    CoutPouvoir.Niveau -= 1;
                }
            }
            else if (ImmuniteElementaire != 0)
            {
                switch (ImmuniteElementaire)
                {
                    case 1:
                        CoutPouvoir.PP = 20;
                        CoutPouvoir.Niveau = 1;
                        break;
                    case 2:
                        CoutPouvoir.PP = 40;
                        CoutPouvoir.Niveau = 1;
                        break;
                    case 3:
                        CoutPouvoir.PP = 80;
                        CoutPouvoir.Niveau = 1;
                        break;
                    case 4:
                        CoutPouvoir.PP = 80;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 5:
                        CoutPouvoir.PP = 80;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 6:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 4;
                        break;
                    default:
                        break;
                }

                if (VoieDisciplineElement == 7)
                {
                    CoutPouvoir.PP += 40;
                }
                else if (VoieDisciplineElement == 8)
                {
                    CoutPouvoir.PP += 80;
                }
            }
            else if (ReductionDegat != 0)
            {
                switch (ReductionDegat)
                {
                    case 1:
                        CoutPouvoir.PP = 80;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 2:
                        CoutPouvoir.PP = 20;
                        CoutPouvoir.Niveau = 4;
                        break;
                    case 3:
                        CoutPouvoir.PP = 80;
                        CoutPouvoir.Niveau = 4;
                        break;
                    default:
                        break;
                }

                if (Limite)
                {
                    CoutPouvoir.Niveau -= 1;
                }
            }
            else if (SeuilInvul != 0)
            {
                switch (SeuilInvul)
                {
                    case 1:
                        CoutPouvoir.PP = 60;
                        CoutPouvoir.Niveau = 1;
                        break;
                    case 2:
                        CoutPouvoir.PP = 40;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 3:
                        CoutPouvoir.PP = 80;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 4:
                        CoutPouvoir.PP = 120;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 5:
                        CoutPouvoir.PP = 180;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 6:
                        CoutPouvoir.PP = 250;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 7:
                        CoutPouvoir.PP = 10;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 8:
                        CoutPouvoir.PP = 20;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 9:
                        CoutPouvoir.PP = 40;
                        CoutPouvoir.Niveau = 3;
                        break;
                    default:
                        break;
                }
            }
            else if (AugmentRes != 0)
            {
                switch (AugmentRes)
                {
                    case 1:
                        CoutPouvoir.PP = 40;
                        CoutPouvoir.Niveau = 1;
                        break;
                    case 2:
                        CoutPouvoir.PP = 20;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 3:
                        CoutPouvoir.PP = 60;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 4:
                        CoutPouvoir.PP = 40;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 5:
                        CoutPouvoir.PP = 120;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 6:
                        CoutPouvoir.PP = 40;
                        CoutPouvoir.Niveau = 4;
                        break;
                    default:
                        break;
                }

                if (TypeResistance == 6 || TypeResistance == 7)
                {
                    CoutPouvoir.PP += 60;
                }
                else if (TypeResistance == 8)
                {
                    CoutPouvoir.Niveau += 1;
                }
                if (Limite)
                {
                    CoutPouvoir.PP -= 20;
                }
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ClassFacetteMagique : ClassFacette
    {
        /// <summary>
        /// index 0 = 0, 1 = +5, 2 = +10, 3 = +15, 4 = +20, 5 = +25, 6 = +30
        /// </summary>
        public int AmpliAMR;
        public int ProjMagique;
        public int ReceptZeon;
        public int PuissAjout;
        public int TestResMysAcc;
        public int RegenZeon;
        public bool Limite;
        public int VoieMagie;

        public ClassFacetteMagique()
        {
            TypePouvoir = TypeFacette.FacetteMagique;

            AmpliAMR = 0;
            ProjMagique = 0;
            ReceptZeon = 0;
            PuissAjout = 0;
            TestResMysAcc = 0;
            RegenZeon = 0;
            Limite = false;
            VoieMagie = 0;

            CoutPouvoir = new ClassCoutPouvoir(0, 0, 0);
        }

        public override void DescriptionPouvoir(List<string> description)
        {
            string tempDesc = "Auncun Bonus.";

            if (AmpliAMR != 0)
            {
                tempDesc = "Augmentation de l'AMR, bonus de +";
                switch (AmpliAMR)
                {
                    case 1:
                        tempDesc += "5.";
                        break;
                    case 2:
                        tempDesc += "10.";
                        break;
                    case 3:
                        tempDesc += "15.";
                        break;
                    case 4:
                        tempDesc += "20.";
                        break;
                    case 5:
                        tempDesc += "25.";
                        break;
                    case 6:
                        tempDesc += "30.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (ProjMagique != 0)
            {
                tempDesc = "Bonus à la prection magique de +";
                switch (ProjMagique)
                {
                    case 1:
                        tempDesc += "5.";
                        break;
                    case 2:
                        tempDesc += "10.";
                        break;
                    case 3:
                        tempDesc += "15.";
                        break;
                    case 4:
                        tempDesc += "20.";
                        break;
                    case 5:
                        tempDesc += "25.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (ReceptZeon != 0)
            {
                tempDesc = "Réceptacle de Zéon de contenance ";
                switch (ReceptZeon)
                {
                    case 1:
                        tempDesc += "de 50.";
                        break;
                    case 2:
                        tempDesc += "de 100.";
                        break;
                    case 3:
                        tempDesc += "de 200.";
                        break;
                    case 4:
                        tempDesc += "de 250.";
                        break;
                    case 5:
                        tempDesc += "de 500.";
                        break;
                    case 6:
                        tempDesc += "de 750.";
                        break;
                    case 7:
                        tempDesc += "de 1000.";
                        break;
                    case 8:
                        tempDesc += "de 1500.";
                        break;
                    case 9:
                        tempDesc += "de 2000.";
                        break;
                    case 10:
                        tempDesc += "de 3000.";
                        break;
                    case 11:
                        tempDesc += "de 5000.";
                        break;
                    case 12:
                        tempDesc += "de 10000.";
                        break;
                    case 13:
                        tempDesc += "illimité.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (PuissAjout != 0)
            {
                tempDesc = "Puissance ajoutée, ajoute ";
                switch (PuissAjout)
                {
                    case 1:
                        tempDesc += "+10 points de Zéon.";
                        break;
                    case 2:
                        tempDesc += "+20 points de Zéon.";
                        break;
                    case 3:
                        tempDesc += "+30 points de Zéon.";
                        break;
                    case 4:
                        tempDesc += "+40 points de Zéon.";
                        break;
                    case 5:
                        tempDesc += "un degré supérieur.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (TestResMysAcc != 0)
            {
                tempDesc = "Test de résistance accrus de +";
                switch (TestResMysAcc)
                {
                    case 1:
                        tempDesc += "10.";
                        break;
                    case 2:
                        tempDesc += "15.";
                        break;
                    case 3:
                        tempDesc += "20.";
                        break;
                    case 4:
                        tempDesc += "25.";
                        break;
                    case 5:
                        tempDesc += "30.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (RegenZeon != 0)
            {
                tempDesc = "Recharge magique, bonus à la régénération ";
                switch (RegenZeon)
                {
                    case 1:
                        tempDesc += " de +10.";
                        break;
                    case 2:
                        tempDesc += "de +20.";
                        break;
                    case 3:
                        tempDesc += "de +30.";
                        break;
                    case 4:
                        tempDesc += "de +40.";
                        break;
                    case 5:
                        tempDesc += "de +50.";
                        break;
                    case 6:
                        tempDesc += "de +60.";
                        break;
                    case 7:
                        tempDesc += "de x2.";
                        break;
                    case 8:
                        tempDesc += "de x3.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }

            if (Limite)
            {
                description.Add(tempDesc);
                tempDesc = "     Limité au ";

                switch (VoieMagie)
                {
                    case 1:
                        tempDesc += "Livre de Lumière.";
                        break;
                    case 2:
                        tempDesc += "Livre d'Obscurité.";
                        break;
                    case 3:
                        tempDesc += "Livre de Création.";
                        break;
                    case 4:
                        tempDesc += "Livre de Destruction.";
                        break;
                    case 5:
                        tempDesc += "Livre d'Air.";
                        break;
                    case 6:
                        tempDesc += "Livre d'Eau.";
                        break;
                    case 7:
                        tempDesc += "Livre de Feu.";
                        break;
                    case 8:
                        tempDesc += "Livre de Terre.";
                        break;
                    case 9:
                        tempDesc += "Livre d'Essence.";
                        break;
                    case 10:
                        tempDesc += "Livre d'Illusion.";
                        break;
                    case 11:
                        tempDesc += "Livre de Nécromancie.";
                        break;
                    default:
                        tempDesc += "Livre non défini.";
                        break;
                }
            }

            description.Add(tempDesc);

            tempDesc = "PP: " + CoutPouvoir.PP + " Niveau: " + CoutPouvoir.Niveau + " Presence: " + CoutPouvoir.Presence + ".";
            description.Add(tempDesc);
        }

        public override string DescriptionPouvoirUneLigne()
        {
            string tempDesc = "Auncun Bonus.";

            if (AmpliAMR != 0)
            {
                tempDesc = "Augmentation de l'AMR, bonus de +";
                switch (AmpliAMR)
                {
                    case 1:
                        tempDesc += "5.";
                        break;
                    case 2:
                        tempDesc += "10.";
                        break;
                    case 3:
                        tempDesc += "15.";
                        break;
                    case 4:
                        tempDesc += "20.";
                        break;
                    case 5:
                        tempDesc += "25.";
                        break;
                    case 6:
                        tempDesc += "30.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (ProjMagique != 0)
            {
                tempDesc = "Bonus à la prection magique de +";
                switch (ProjMagique)
                {
                    case 1:
                        tempDesc += "5.";
                        break;
                    case 2:
                        tempDesc += "10.";
                        break;
                    case 3:
                        tempDesc += "15.";
                        break;
                    case 4:
                        tempDesc += "20.";
                        break;
                    case 5:
                        tempDesc += "25.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (ReceptZeon != 0)
            {
                tempDesc = "Réceptacle de Zéon de contenance ";
                switch (ReceptZeon)
                {
                    case 1:
                        tempDesc += "de 50.";
                        break;
                    case 2:
                        tempDesc += "de 100.";
                        break;
                    case 3:
                        tempDesc += "de 200.";
                        break;
                    case 4:
                        tempDesc += "de 250.";
                        break;
                    case 5:
                        tempDesc += "de 500.";
                        break;
                    case 6:
                        tempDesc += "de 750.";
                        break;
                    case 7:
                        tempDesc += "de 1000.";
                        break;
                    case 8:
                        tempDesc += "de 1500.";
                        break;
                    case 9:
                        tempDesc += "de 2000.";
                        break;
                    case 10:
                        tempDesc += "de 3000.";
                        break;
                    case 11:
                        tempDesc += "de 5000.";
                        break;
                    case 12:
                        tempDesc += "de 10000.";
                        break;
                    case 13:
                        tempDesc += "illimité.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (PuissAjout != 0)
            {
                tempDesc = "Puissance ajoutée, ajoute ";
                switch (PuissAjout)
                {
                    case 1:
                        tempDesc += "+10 points de Zéon.";
                        break;
                    case 2:
                        tempDesc += "+20 points de Zéon.";
                        break;
                    case 3:
                        tempDesc += "+30 points de Zéon.";
                        break;
                    case 4:
                        tempDesc += "+40 points de Zéon.";
                        break;
                    case 5:
                        tempDesc += "un degré supérieur.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (TestResMysAcc != 0)
            {
                tempDesc = "Test de résistance accrus de +";
                switch (TestResMysAcc)
                {
                    case 1:
                        tempDesc += "10.";
                        break;
                    case 2:
                        tempDesc += "15.";
                        break;
                    case 3:
                        tempDesc += "20.";
                        break;
                    case 4:
                        tempDesc += "25.";
                        break;
                    case 5:
                        tempDesc += "30.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (RegenZeon != 0)
            {
                tempDesc = "Recharge magique, bonus à la régénération ";
                switch (RegenZeon)
                {
                    case 1:
                        tempDesc += " de +10.";
                        break;
                    case 2:
                        tempDesc += "de +20.";
                        break;
                    case 3:
                        tempDesc += "de +30.";
                        break;
                    case 4:
                        tempDesc += "de +40.";
                        break;
                    case 5:
                        tempDesc += "de +50.";
                        break;
                    case 6:
                        tempDesc += "de +60.";
                        break;
                    case 7:
                        tempDesc += "de x2.";
                        break;
                    case 8:
                        tempDesc += "de x3.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            return tempDesc;
        }

        public override void ExportXML(XmlWriter writer)
        {
            throw new NotImplementedException();
        }

        public override void GenererCoutPouvoir()
        {
            CoutPouvoir = new ClassCoutPouvoir(0, 0);

            if (AmpliAMR != 0)
            {
                switch (AmpliAMR)
                {
                    case 1:
                        CoutPouvoir.PP = 150;
                        CoutPouvoir.Niveau = 1;
                        break;
                    case 2:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 3:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 4:
                        CoutPouvoir.PP = 150;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 5:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 4;
                        break;
                    case 6:
                        CoutPouvoir.PP = 200;
                        CoutPouvoir.Niveau = 4;
                        break;
                    default:
                        break;
                }
                if (Limite)
                {
                    CoutPouvoir.Niveau -= 1;
                    if (CoutPouvoir.Niveau < 1)
                    {
                        CoutPouvoir.Niveau = 1;
                    }
                }
            }
            else if (ProjMagique != 0)
            {
                switch (ProjMagique)
                {
                    case 1:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 1;
                        break;
                    case 2:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 3:
                        CoutPouvoir.PP = 150;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 4:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 5:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 4;
                        break;
                    default:
                        break;
                }
                if (Limite)
                {
                    CoutPouvoir.PP -= 20;
                }
            }
            else if (ReceptZeon != 0)
            {
                switch (ReceptZeon)
                {
                    case 1:
                        CoutPouvoir.PP = 20;
                        CoutPouvoir.Niveau = 1;
                        break;
                    case 2:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 1;
                        break;
                    case 3:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 1;
                        break;
                    case 4:
                        CoutPouvoir.PP = 20;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 5:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 6:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 7:
                        CoutPouvoir.PP = 20;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 8:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 9:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 10:
                        CoutPouvoir.PP = 20;
                        CoutPouvoir.Niveau = 4;
                        break;
                    case 11:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 4;
                        break;
                    case 12:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 4;
                        break;
                    case 13:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 5;
                        break;
                    default:
                        break;
                }
            }
            else if (PuissAjout != 0)
            {
                switch (PuissAjout)
                {
                    case 1:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 1;
                        break;
                    case 2:
                        CoutPouvoir.PP = 20;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 3:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 4:
                        CoutPouvoir.PP = 140;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 5:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 3;
                        break;
                    default:
                        break;
                }
                if (Limite)
                {
                    CoutPouvoir.PP -= 20;
                }
            }
            else if (TestResMysAcc != 0)
            {
                switch (TestResMysAcc)
                {
                    case 1:
                        CoutPouvoir.PP = 40;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 2:
                        CoutPouvoir.PP = 120;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 3:
                        CoutPouvoir.PP = 40;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 4:
                        CoutPouvoir.PP = 40;
                        CoutPouvoir.Niveau = 4;
                        break;
                    case 5:
                        CoutPouvoir.PP = 120;
                        CoutPouvoir.Niveau = 4;
                        break;
                    default:
                        break;
                }
                if (Limite)
                {
                    CoutPouvoir.PP -= 20;
                }
            }
            else if (RegenZeon != 0)
            {
                switch (RegenZeon)
                {
                    case 1:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 1;
                        break;
                    case 2:
                        CoutPouvoir.PP = 250;
                        CoutPouvoir.Niveau = 1;
                        break;
                    case 3:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 4:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 5:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 6:
                        CoutPouvoir.PP = 150;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 7:
                        CoutPouvoir.PP = 200;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 8:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 4;
                        break;
                    default:
                        break;
                }
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ClassFacettePsychique : ClassFacette
    {
        /// <summary>
        /// index 0 = 0, 1 = +5, 2 = +10, 3 = +15, 4 = +20, 5 = +25, 6 = +30
        /// </summary>
        public int Talent;
        /// <summary>
        /// index 0 = 0, 1 = +5, 2 = +10, 3 = +15, 4 = +20, 5 = +25
        /// </summary>
        public int ProjectionPsy;
        /// <summary>
        /// index 0 = 0, 1 = +10, 2 = +15, 3 = +20, 4 = +25, 5 = +30
        /// </summary>
        public int TestResPsyAccrus;
        /// <summary>
        /// index 0 = 0, 1 = +10, 2 = +20, 3 = +30, 4 = +40, 5 = +50
        /// </summary>
        public int MaintPouvoir;
        /// <summary>
        /// Si le pouvoir est limité a certaine discipline
        /// </summary>
        public bool Limite;
        /// <summary>
        /// index 
        /// </summary>
        public int Discipline;

        public ClassFacettePsychique()
        {
            TypePouvoir = TypeFacette.FacettePsychique;

            Talent = 0;
            ProjectionPsy = 0;
            TestResPsyAccrus = 0;
            MaintPouvoir = 0;
            Limite = false;
            Discipline = 0;

            CoutPouvoir = new ClassCoutPouvoir(0, 0, 0);
        }

        public override void DescriptionPouvoir(List<string> description)
        {
            string tempDesc = "Auncun Bonus.";

            if (Talent != 0)
            {
                tempDesc = "Talent, bonus de +";
                switch (Talent)
                {
                    case 1:
                        tempDesc += "5.";
                        break;
                    case 2:
                        tempDesc += "10.";
                        break;
                    case 3:
                        tempDesc += "15.";
                        break;
                    case 4:
                        tempDesc += "20.";
                        break;
                    case 5:
                        tempDesc += "25.";
                        break;
                    case 6:
                        tempDesc += "30.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (ProjectionPsy != 0)
            {
                tempDesc = "Bonus à la prection psychique de +";
                switch (ProjectionPsy)
                {
                    case 1:
                        tempDesc += "5.";
                        break;
                    case 2:
                        tempDesc += "10.";
                        break;
                    case 3:
                        tempDesc += "15.";
                        break;
                    case 4:
                        tempDesc += "20.";
                        break;
                    case 5:
                        tempDesc += "25.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (TestResPsyAccrus != 0)
            {
                tempDesc = "Test de résistance psychique accrus de +";
                switch (TestResPsyAccrus)
                {
                    case 1:
                        tempDesc += "10.";
                        break;
                    case 2:
                        tempDesc += "15.";
                        break;
                    case 3:
                        tempDesc += "20.";
                        break;
                    case 4:
                        tempDesc += "25.";
                        break;
                    case 5:
                        tempDesc += "30.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (MaintPouvoir != 0)
            {
                tempDesc = "Amélioration du maintient, bonus au talent de +";
                switch (MaintPouvoir)
                {
                    case 1:
                        tempDesc += "10.";
                        break;
                    case 2:
                        tempDesc += "20.";
                        break;
                    case 3:
                        tempDesc += "30.";
                        break;
                    case 4:
                        tempDesc += "40.";
                        break;
                    case 5:
                        tempDesc += "50.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }

            if (Limite)
            {
                description.Add(tempDesc);
                tempDesc = "     Limité a la discpline de ";

                switch (Discipline)
                {
                    case 1:
                        tempDesc += "Télépathie.";
                        break;
                    case 2:
                        tempDesc += "Télékinésie.";
                        break;
                    case 3:
                        tempDesc += "Pyrokinésie.";
                        break;
                    case 4:
                        tempDesc += "Cryokinésie.";
                        break;
                    case 5:
                        tempDesc += "Augmentation physique.";
                        break;
                    case 6:
                        tempDesc += "Énergie.";
                        break;
                    case 7:
                        tempDesc += "Sensation.";
                        break;
                    case 8:
                        tempDesc += "Télémétrie.";
                        break;
                    case 9:
                        tempDesc += "Causalité.";
                        break;
                    case 10:
                        tempDesc += "Électromagnétisme.";
                        break;
                    case 11:
                        tempDesc += "Téléportation.";
                        break;
                    case 12:
                        tempDesc += "Lumière.";
                        break;
                    case 13:
                        tempDesc += "Hypersensibilité.";
                        break;
                    default:
                        tempDesc += "Discipline non défini.";
                        break;
                }
            }

            description.Add(tempDesc);

            tempDesc = "PP: " + CoutPouvoir.PP + " Niveau: " + CoutPouvoir.Niveau + " Presence: " + CoutPouvoir.Presence + ".";
            description.Add(tempDesc);
        }

        public override string DescriptionPouvoirUneLigne()
        {
            string tempDesc = "Auncun Bonus.";

            if (Talent != 0)
            {
                tempDesc = "Talent, bonus de +";
                switch (Talent)
                {
                    case 1:
                        tempDesc += "5.";
                        break;
                    case 2:
                        tempDesc += "10.";
                        break;
                    case 3:
                        tempDesc += "15.";
                        break;
                    case 4:
                        tempDesc += "20.";
                        break;
                    case 5:
                        tempDesc += "25.";
                        break;
                    case 6:
                        tempDesc += "30.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (ProjectionPsy != 0)
            {
                tempDesc = "Bonus à la prection psychique de +";
                switch (ProjectionPsy)
                {
                    case 1:
                        tempDesc += "5.";
                        break;
                    case 2:
                        tempDesc += "10.";
                        break;
                    case 3:
                        tempDesc += "15.";
                        break;
                    case 4:
                        tempDesc += "20.";
                        break;
                    case 5:
                        tempDesc += "25.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (TestResPsyAccrus != 0)
            {
                tempDesc = "Test de résistance psychique accrus de +";
                switch (TestResPsyAccrus)
                {
                    case 1:
                        tempDesc += "10.";
                        break;
                    case 2:
                        tempDesc += "15.";
                        break;
                    case 3:
                        tempDesc += "20.";
                        break;
                    case 4:
                        tempDesc += "25.";
                        break;
                    case 5:
                        tempDesc += "30.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (MaintPouvoir != 0)
            {
                tempDesc = "Amélioration du maintient, bonus au talent de +";
                switch (MaintPouvoir)
                {
                    case 1:
                        tempDesc += "10.";
                        break;
                    case 2:
                        tempDesc += "20.";
                        break;
                    case 3:
                        tempDesc += "30.";
                        break;
                    case 4:
                        tempDesc += "40.";
                        break;
                    case 5:
                        tempDesc += "50.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            return tempDesc;
        }

        public override void ExportXML(XmlWriter writer)
        {
            throw new NotImplementedException();
        }

        public override void GenererCoutPouvoir()
        {
            CoutPouvoir = new ClassCoutPouvoir(0, 0);

            if (Talent != 0)
            {
                switch (Talent)
                {
                    case 1:
                        CoutPouvoir.PP = 150;
                        CoutPouvoir.Niveau = 1;
                        break;
                    case 2:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 3:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 4:
                        CoutPouvoir.PP = 150;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 5:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 4;
                        break;
                    case 6:
                        CoutPouvoir.PP = 200;
                        CoutPouvoir.Niveau = 4;
                        break;
                    default:
                        break;
                }
                if (Limite)
                {
                    CoutPouvoir.Niveau -= 1;
                    if (CoutPouvoir.Niveau < 1)
                    {
                        CoutPouvoir.Niveau = 1;
                    }
                }
            }
            else if (ProjectionPsy != 0)
            {
                switch (ProjectionPsy)
                {
                    case 1:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 1;
                        break;
                    case 2:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 3:
                        CoutPouvoir.PP = 150;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 4:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 5:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 4;
                        break;
                    default:
                        break;
                }
                if (Limite)
                {
                    CoutPouvoir.PP -= 20;
                }
            }
            else if (TestResPsyAccrus != 0)
            {
                switch (TestResPsyAccrus)
                {
                    case 1:
                        CoutPouvoir.PP = 40;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 2:
                        CoutPouvoir.PP = 120;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 3:
                        CoutPouvoir.PP = 40;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 4:
                        CoutPouvoir.PP = 40;
                        CoutPouvoir.Niveau = 4;
                        break;
                    case 5:
                        CoutPouvoir.PP = 40;
                        CoutPouvoir.Niveau = 5;
                        break;
                    default:
                        break;
                }
                if (Limite)
                {
                    CoutPouvoir.PP -= 20;
                }
            }
            else if (MaintPouvoir != 0)
            {
                switch (MaintPouvoir)
                {
                    case 1:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 1;
                        break;
                    case 2:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 3:
                        CoutPouvoir.PP = 150;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 4:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 4;
                        break;
                    case 5:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 5;
                        break;
                    default:
                        break;
                }
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ClassFacetteConvocation : ClassFacette
    {
        public int PresenceAccrue;
        public int LienEconome;
        public int ConvoAccrue;
        public bool LienElem;
        public int ElementLie;
        public bool ConvoSeul;
        public int ConvoLie;
        public bool Invocation;
        public bool RituelReq;

        public ClassFacetteConvocation()
        {
            TypePouvoir = TypeFacette.FacetteConvocation;

            PresenceAccrue = 0;
            LienEconome = 0;
            ConvoAccrue = 0;
            LienElem = false;
            ElementLie = 0;
            ConvoSeul = false;
            ConvoLie = 0;
            Invocation = false;
            RituelReq = false;

            CoutPouvoir = new ClassCoutPouvoir(0, 0, 0);
        }

        public override void DescriptionPouvoir(List<string> description)
        {
            string tempDesc = "Auncun Bonus.";

            if (PresenceAccrue != 0)
            {
                tempDesc = "Présence accrue, bonus de +";
                switch (PresenceAccrue)
                {
                    case 1:
                        tempDesc += "10.";
                        break;
                    case 2:
                        tempDesc += "20.";
                        break;
                    case 3:
                        tempDesc += "30.";
                        break;
                    case 4:
                        tempDesc += "50.";
                        break;
                    case 5:
                        tempDesc += "75.";
                        break;
                    case 6:
                        tempDesc += "100.";
                        break;
                    case 7:
                        tempDesc += "150.";
                        break;
                    case 8:
                        tempDesc += "200.";
                        break;
                    case 9:
                        tempDesc += "250.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (LienEconome != 0)
            {
                tempDesc = "Lien économe, reduction de ";
                switch (LienEconome)
                {
                    case 1:
                        tempDesc += "1 niveau.";
                        break;
                    case 2:
                        tempDesc += "2 niveaux.";
                        break;
                    case 3:
                        tempDesc += "3 niveaux.";
                        break;
                    case 4:
                        tempDesc += "4 niveaux.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (ConvoAccrue != 0)
            {
                tempDesc = "Convocation accrue, bonus de +";
                switch (ConvoAccrue)
                {
                    case 1:
                        tempDesc += "5.";
                        break;
                    case 2:
                        tempDesc += "10.";
                        break;
                    case 3:
                        tempDesc += "15.";
                        break;
                    case 4:
                        tempDesc += "20.";
                        break;
                    case 5:
                        tempDesc += "25.";
                        break;
                    case 6:
                        tempDesc += "30.";
                        break;
                    case 7:
                        tempDesc += "40.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }

            if (ConvoLie != 0)
            {
                description.Add(tempDesc);
                tempDesc = "     Applicable à la compétence ";
                switch (ConvoLie)
                {
                    case 1:
                        tempDesc += "convoquer.";

                        if (ConvoSeul)
                        {
                            description.Add(tempDesc);
                            tempDesc = "     Uniquement pour convoquer(pas d'invocation).";
                        }
                        else if (Invocation)
                        {
                            description.Add(tempDesc);
                            tempDesc = "     Uniquement pour invoquer(pas de convocation).";
                        }
                        break;
                    case 2:
                        tempDesc += "dominer.";
                        break;
                    case 3:
                        tempDesc += "lier.";
                        break;
                    case 4:
                        tempDesc += "révoquer.";
                        break;
                    default:
                        tempDesc = "non définie.";
                        break;
                }
                if (RituelReq)
                {
                    description.Add(tempDesc);
                    tempDesc = "     Nécessité rituelle.";
                }
            }

            if (LienElem)
            {
                description.Add(tempDesc);
                tempDesc = "     Lien élémetaire avec ";
                switch (ElementLie)
                {
                    case 1:
                        tempDesc += "l'air.";
                        break;
                    case 2:
                        tempDesc += "la terre.";
                        break;
                    case 3:
                        tempDesc += "le feu.";
                        break;
                    case 4:
                        tempDesc += "l'eau.";
                        break;
                    case 5:
                        tempDesc += "la noirceur.";
                        break;
                    case 6:
                        tempDesc += "la lumière.";
                        break;
                    default:
                        tempDesc += "Élément non défini.";
                        break;
                }
            }
            description.Add(tempDesc);

            tempDesc = "PP: " + CoutPouvoir.PP + " Niveau: " + CoutPouvoir.Niveau + " Presence: " + CoutPouvoir.Presence + ".";
            description.Add(tempDesc);
        }

        public override string DescriptionPouvoirUneLigne()
        {
            string tempDesc = "Auncun Bonus.";

            if (PresenceAccrue != 0)
            {
                tempDesc = "Présence accrue, bonus de +";
                switch (PresenceAccrue)
                {
                    case 1:
                        tempDesc += "10.";
                        break;
                    case 2:
                        tempDesc += "20.";
                        break;
                    case 3:
                        tempDesc += "30.";
                        break;
                    case 4:
                        tempDesc += "50.";
                        break;
                    case 5:
                        tempDesc += "75.";
                        break;
                    case 6:
                        tempDesc += "100.";
                        break;
                    case 7:
                        tempDesc += "150.";
                        break;
                    case 8:
                        tempDesc += "200.";
                        break;
                    case 9:
                        tempDesc += "250.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (LienEconome != 0)
            {
                tempDesc = "Lien économe, reduction de ";
                switch (LienEconome)
                {
                    case 1:
                        tempDesc += "1 niveau.";
                        break;
                    case 2:
                        tempDesc += "2 niveaux.";
                        break;
                    case 3:
                        tempDesc += "3 niveaux.";
                        break;
                    case 4:
                        tempDesc += "4 niveaux.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (ConvoAccrue != 0)
            {
                tempDesc = "Convocation accrue, bonus de +";
                switch (ConvoAccrue)
                {
                    case 1:
                        tempDesc += "5.";
                        break;
                    case 2:
                        tempDesc += "10.";
                        break;
                    case 3:
                        tempDesc += "15.";
                        break;
                    case 4:
                        tempDesc += "20.";
                        break;
                    case 5:
                        tempDesc += "25.";
                        break;
                    case 6:
                        tempDesc += "30.";
                        break;
                    case 7:
                        tempDesc += "40.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            return tempDesc;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override void ExportXML(XmlWriter writer)
        {
            throw new NotImplementedException();
        }

        public override void GenererCoutPouvoir()
        {
            CoutPouvoir = new ClassCoutPouvoir(0, 0, 0);

            if (PresenceAccrue != 0)
            {
                switch (PresenceAccrue)
                {
                    case 1:
                        CoutPouvoir.PP = 25;
                        CoutPouvoir.Niveau = 1;
                        break;
                    case 2:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 1;
                        break;
                    case 3:
                        CoutPouvoir.PP = 75;
                        CoutPouvoir.Niveau = 1;
                        break;
                    case 4:
                        CoutPouvoir.PP = 25;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 5:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 6:
                        CoutPouvoir.PP = 75;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 7:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 8:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 9:
                        CoutPouvoir.PP = 150;
                        CoutPouvoir.Niveau = 3;
                        break;
                    default:
                        break;
                }
            }
            else if (LienEconome != 0)
            {
                switch (LienEconome)
                {
                    case 1:
                        CoutPouvoir.PP = 150;
                        CoutPouvoir.Niveau = 1;
                        break;
                    case 2:
                        CoutPouvoir.PP = 150;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 3:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 4:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 4;
                        break;
                    default:
                        break;
                }
                if (LienElem)
                {
                    CoutPouvoir.PP -= 20;
                }
            }
            else if (ConvoAccrue != 0)
            {
                switch (ConvoAccrue)
                {
                    case 1:
                        CoutPouvoir.PP = 20;
                        CoutPouvoir.Niveau = 1;
                        break;
                    case 2:
                        CoutPouvoir.PP = 40;
                        CoutPouvoir.Niveau = 1;
                        break;
                    case 3:
                        CoutPouvoir.PP = 20;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 4:
                        CoutPouvoir.PP = 40;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 5:
                        CoutPouvoir.PP = 80;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 6:
                        CoutPouvoir.PP = 20;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 7:
                        CoutPouvoir.PP = 40;
                        CoutPouvoir.Niveau = 4;
                        break;
                    default:
                        break;
                }
                if (LienElem)
                {
                    CoutPouvoir.PP -= 20;
                }
                if (ConvoSeul)
                {
                    CoutPouvoir.PP -= 10;
                }
                else if (Invocation)
                {
                    CoutPouvoir.PP -= 10;
                }
                if (RituelReq)
                {
                    CoutPouvoir.PP -= 20;
                }
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ClassSort
    {
        public int NiveauSort;
        public int CoutZeon;
        public string NomSort;
        public int Voie;
        public ClassCoutPouvoir CoutPouvoir;

        public ClassSort(int niveau, int cout, string nom, int voie)
        {
            NiveauSort = niveau;
            CoutZeon = cout;
            NomSort = nom;
            Voie = voie;

            CoutPouvoir = new ClassCoutPouvoir(0, 0, 0);
        }

        public string DescriptionSort()
        {
            string tempDesc = "";

            tempDesc = NomSort + " d";
            switch (Voie)
            {
                case 1:
                    tempDesc += "e la Lumière";
                    break;
                case 2:
                    tempDesc += "e l'Obscurité";
                    break;
                case 3:
                    tempDesc += "e la Création";
                    break;
                case 4:
                    tempDesc += "e la Destruction";
                    break;
                case 5:
                    tempDesc += "e l'Air";
                    break;
                case 6:
                    tempDesc += "e l'Eau";
                    break;
                case 7:
                    tempDesc += "u Feu";
                    break;
                case 8:
                    tempDesc += "e la Terre";
                    break;
                case 9:
                    tempDesc += "e l'Essence";
                    break;
                case 10:
                    tempDesc += "e l'Illusion";
                    break;
                case 11:
                    tempDesc += "e la Nécromancie";
                    break;
                default:
                    tempDesc += "e la Non défini";
                    break;
            }
            tempDesc += "(" + NiveauSort + ") " + CoutZeon + " Zéons.";

            return tempDesc;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ClassFacetteMagieInnee : ClassFacette
    {
        public List<ClassSort> SortAutomatique;
        public List<ClassSort> LanceurSort;
        public int CompLancement;
        /// <summary>
        /// Mod de sort auto
        /// </summary>
        public int NBUtil;
        public bool Illimite;
        public bool RechargeReduite;
        public int PrepTime;
        public int CoutCondition;
        public string DescCondition;
        /// <summary>
        /// Mod de lanceur de sort
        /// </summary>
        public bool SansDon;
        public bool AMRDouble;
        public bool Inne;
        public bool CoutReduit;
        public bool Autonomie;
        /// <summary>
        /// 
        /// </summary>
        public bool ResulatFinal;

        public ClassFacetteMagieInnee()
        {
            TypePouvoir = TypeFacette.FacetteInnee;

            SortAutomatique = new List<ClassSort>();
            LanceurSort = new List<ClassSort>();
            CompLancement = 0;
            NBUtil = -1;
            Illimite = false;
            RechargeReduite = false;
            PrepTime = 0;
            CoutCondition = 0;
            DescCondition = "";
            SansDon = false;
            AMRDouble = false;
            Inne = false;
            CoutReduit = false;
            Autonomie = false;
            ResulatFinal = false;

            CoutPouvoir = new ClassCoutPouvoir(0, 0, 0);
        }

        public override void DescriptionPouvoir(List<string> description)
        {
            string tempDesc = "Auncun Bonus.";

            if (SortAutomatique.Count != 0)
            {
                tempDesc = "Sort automatique:";
                foreach (ClassSort sort in SortAutomatique)
                {
                    description.Add(tempDesc);
                    tempDesc = "        " + sort.DescriptionSort();
                }
                if (!Illimite)
                {
                    description.Add(tempDesc);
                    tempDesc = "     Utilisable " + (NBUtil + 1) + " fois par jour.";
                }
                else
                {
                    description.Add(tempDesc);
                    tempDesc = "     Utilisation illimité.";
                }
                if (RechargeReduite)
                {
                    description.Add(tempDesc);
                    tempDesc = "     Recharge réduite.";
                }
                if (PrepTime != 0)
                {
                    description.Add(tempDesc);
                    tempDesc = "     Requiert " + PrepTime + " round de préparation.";
                }
                if (CoutCondition != 0)
                {
                    description.Add(tempDesc);
                    tempDesc = "     Condition d'activation: " + DescCondition + ".";
                }
            }
            else if (LanceurSort.Count != 0)
            {
                tempDesc = "Lanceur de sorts:";
                foreach (ClassSort sort in LanceurSort)
                {
                    description.Add(tempDesc);
                    tempDesc = "        " + sort.DescriptionSort();
                }
                if (SansDon)
                {
                    description.Add(tempDesc);
                    tempDesc = "     Sans le Don.";
                }
                if (AMRDouble)
                {
                    description.Add(tempDesc);
                    tempDesc = "     AMR double.";
                }
                if (Inne)
                {
                    description.Add(tempDesc);
                    tempDesc = "     Inné.";
                }
                if (CoutReduit)
                {
                    description.Add(tempDesc);
                    tempDesc = "     Coût réduit de moitié.";
                }
                if (Autonomie)
                {
                    description.Add(tempDesc);
                    tempDesc = "     Autonomie d'énergie.";
                }
            }
            else if (CompLancement != 0)
            {
                tempDesc = "Compétence de lancement de ";
                switch (CompLancement)
                {
                    case 1:
                        tempDesc += "80.";
                        break;
                    case 2:
                        tempDesc += "120.";
                        break;
                    case 3:
                        tempDesc += "160.";
                        break;
                    case 4:
                        tempDesc += "200.";
                        break;
                    case 5:
                        tempDesc += "240.";
                        break;
                    case 6:
                        tempDesc += "280.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
                if (ResulatFinal)
                {
                    description.Add(tempDesc);
                    tempDesc = "     Résultat final.";
                }
            }
            description.Add(tempDesc);

            tempDesc = "PP: " + CoutPouvoir.PP + " Niveau: " + CoutPouvoir.Niveau + " Presence:" + CoutPouvoir.Presence + ".";
            description.Add(tempDesc);
        }

        public override string DescriptionPouvoirUneLigne()
        {
            string tempDesc = "Auncun Bonus.";
            bool first = true;

            if (SortAutomatique.Count != 0)
            {
                tempDesc = "Sort automatique:";
                
                foreach (ClassSort sort in SortAutomatique)
                {
                    if (first)
                    {
                        tempDesc += " " + sort.DescriptionSort();
                        first = false;
                    }
                    else
                        tempDesc += ", " + sort.DescriptionSort();
                }
                tempDesc += ".";
            }
            else if (LanceurSort.Count != 0)
            {
                tempDesc = "Lanceur de sorts: ";
                first = true;
                foreach (ClassSort sort in LanceurSort)
                {
                    if (first)
                    {
                        tempDesc += " " + sort.DescriptionSort();
                        first = false;
                    }
                    else
                        tempDesc += ", " + sort.DescriptionSort();
                }
                tempDesc += ".";
            }
            else if (CompLancement != 0)
            {
                tempDesc = "Compétence de lancement de ";
                switch (CompLancement)
                {
                    case 1:
                        tempDesc += "80.";
                        break;
                    case 2:
                        tempDesc += "120.";
                        break;
                    case 3:
                        tempDesc += "160.";
                        break;
                    case 4:
                        tempDesc += "200.";
                        break;
                    case 5:
                        tempDesc += "240.";
                        break;
                    case 6:
                        tempDesc += "280.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            return tempDesc;
        }

        public override void ExportXML(XmlWriter writer)
        {
            throw new NotImplementedException();
        }

        public override void GenererCoutPouvoir()
        {
            CoutPouvoir = new ClassCoutPouvoir(0, 0, 0);

            if (SortAutomatique.Count != 0)
            {
                foreach (ClassSort sort in SortAutomatique)
                {
                    sort.CoutPouvoir = new ClassCoutPouvoir(0, 0, 0);
                    sort.CoutPouvoir.PP = 5 * (int)Math.Round(sort.CoutZeon / 2 / 5.0, MidpointRounding.ToEven);
                    if (sort.NiveauSort >= 2 && sort.NiveauSort <= 10)
                    {
                        sort.CoutPouvoir.Niveau = 1;
                    }
                    else if (sort.NiveauSort >= 12 && sort.NiveauSort <= 50)
                    {
                        sort.CoutPouvoir.Niveau = 2;
                    }
                    else if (sort.NiveauSort >= 52 && sort.NiveauSort <= 80)
                    {
                        sort.CoutPouvoir.Niveau = 3;
                    }
                    else if (sort.NiveauSort >= 82 && sort.NiveauSort <= 90)
                    {
                        sort.CoutPouvoir.Niveau = 4;
                    }
                    CoutPouvoir.PP += sort.CoutPouvoir.PP;
                    if (CoutPouvoir.Niveau < sort.CoutPouvoir.Niveau)
                    {
                        CoutPouvoir.Niveau = sort.CoutPouvoir.Niveau;
                    }
                }
                if (!Illimite)
                {
                    CoutPouvoir.PP += (NBUtil * 10);
                }
                else
                {
                    CoutPouvoir.Niveau += 1;
                }
                if (RechargeReduite)
                {
                    CoutPouvoir.PP += 100;
                }
                if (PrepTime != 0)
                {
                    CoutPouvoir.PP -= (PrepTime * 5);
                }
                if (CoutCondition != 0)
                {
                    CoutPouvoir.PP -= CoutCondition;
                }
            }
            else if (LanceurSort.Count != 0)
            {
                foreach (ClassSort sort in LanceurSort)
                {
                    sort.CoutPouvoir = new ClassCoutPouvoir(0, 0);
                    sort.CoutPouvoir.PP = 5 * (int)Math.Round(sort.CoutZeon / 4 / 5.0, MidpointRounding.ToEven);
                    if (sort.NiveauSort >= 2 && sort.NiveauSort <= 10)
                    {
                        sort.CoutPouvoir.Niveau = 1;
                    }
                    else if (sort.NiveauSort >= 12 && sort.NiveauSort <= 50)
                    {
                        sort.CoutPouvoir.Niveau = 2;
                    }
                    else if (sort.NiveauSort >= 52 && sort.NiveauSort <= 80)
                    {
                        sort.CoutPouvoir.Niveau = 3;
                    }
                    else if (sort.NiveauSort >= 82 && sort.NiveauSort <= 90)
                    {
                        sort.CoutPouvoir.Niveau = 4;
                    }
                    CoutPouvoir.PP += sort.CoutPouvoir.PP;
                    if (CoutPouvoir.Niveau < sort.CoutPouvoir.Niveau)
                    {
                        CoutPouvoir.Niveau = sort.CoutPouvoir.Niveau;
                    }
                }
                if (SansDon)
                {
                    CoutPouvoir.PP += 40;
                }
                if (AMRDouble)
                {
                    CoutPouvoir.PP += 20;
                }
                if (Inne)
                {
                    CoutPouvoir.PP += 20;
                }
                if (CoutReduit)
                {
                    CoutPouvoir.Niveau += 1;
                }
                if (Autonomie)
                {
                    CoutPouvoir.PP += 40;
                }
            }
            else if (CompLancement != 0)
            {
                switch (CompLancement)
                {
                    case 1:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 2:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 3:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 4:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 5:
                        CoutPouvoir.PP = 250;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 6:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 4;
                        break;
                    default:
                        break;
                }
                if (ResulatFinal)
                {
                    CoutPouvoir.Niveau -= 1;
                }
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ClassFacetteAugmentation : ClassFacette
    {
        public int Initiative;
        public int Regeneration;
        public int AugDeplacement;
        public int AugCompSec;
        public int AugCarac;
        public int SubstiCarac;
        public bool Confontation;
        public string Competence;

        public ClassFacetteAugmentation()
        {
            TypePouvoir = TypeFacette.FacetteAugmentation;

            Initiative = 0;
            Regeneration = 0;
            AugDeplacement = 0;
            AugCompSec = 0;
            AugCarac = 0;
            SubstiCarac = 0;
            Confontation = false;

            CoutPouvoir = new ClassCoutPouvoir(0, 0, 0);
        }

        public override void DescriptionPouvoir(List<string> description)
        {
            string tempDesc = "Auncun Bonus.";

            if (Initiative != 0)
            {
                tempDesc = "Initiative augmenté, bonus de +";
                switch (Initiative)
                {
                    case 1:
                        tempDesc += "5.";
                        break;
                    case 2:
                        tempDesc += "10.";
                        break;
                    case 3:
                        tempDesc += "15.";
                        break;
                    case 4:
                        tempDesc += "20.";
                        break;
                    case 5:
                        tempDesc += "25.";
                        break;
                    case 6:
                        tempDesc += "30.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (Regeneration != 0)
            {
                tempDesc = "Régénération augmenté: ";
                switch (Regeneration)
                {
                    case 1:
                        tempDesc += "Régénération 4.";
                        break;
                    case 2:
                        tempDesc += "Régénération 8.";
                        break;
                    case 3:
                        tempDesc += "Régénération 12.";
                        break;
                    case 4:
                        tempDesc += "Régénération 14.";
                        break;
                    case 5:
                        tempDesc += "Régénération 16.";
                        break;
                    case 6:
                        tempDesc += "Régénération +1.";
                        break;
                    case 7:
                        tempDesc += "Régénération +2.";
                        break;
                    case 8:
                        tempDesc += "Régénération +4.";
                        break;
                    case 9:
                        tempDesc += "Régénération +6.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (AugDeplacement != 0)
            {
                tempDesc = "Augmentation du déplacement, bonus de +";
                switch (AugDeplacement)
                {
                    case 1:
                        tempDesc += "1.";
                        break;
                    case 2:
                        tempDesc += "2.";
                        break;
                    case 3:
                        tempDesc += "3.";
                        break;
                    case 4:
                        tempDesc += "4.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (AugCompSec != 0)
            {
                tempDesc = "Augmentation des compétences secondaires, bonus de +";
                switch (AugCompSec)
                {
                    case 1:
                        tempDesc += "10.";
                        break;
                    case 2:
                        tempDesc += "25.";
                        break;
                    case 3:
                        tempDesc += "50.";
                        break;
                    case 4:
                        tempDesc += "75.";
                        break;
                    case 5:
                        tempDesc += "100.";
                        break;
                    case 6:
                        tempDesc += "10 Champ complet.";
                        break;
                    case 7:
                        tempDesc += "20 Champ complet.";
                        break;
                    case 8:
                        tempDesc += "30 Champ complet.";
                        break;
                    case 9:
                        tempDesc += "40 Champ complet.";
                        break;
                    case 10:
                        tempDesc += "50 Champ complet.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
                if (AugCompSec > 5)
                {
                    description.Add(tempDesc);
                    tempDesc = "     Au champ " + Competence + ".";
                }
                else
                {
                    description.Add(tempDesc);
                    tempDesc = "     À la compétence " + Competence + ".";
                }
            }
            else if (AugCarac != 0)
            {
                tempDesc = "Augmentation des caractéristiques, bonus de +";
                switch (AugCarac)
                {
                    case 1:
                        tempDesc += "1.";
                        break;
                    case 2:
                        tempDesc += "2.";
                        break;
                    case 3:
                        tempDesc += "3.";
                        break;
                    case 4:
                        tempDesc += "4.";
                        break;
                    case 5:
                        tempDesc += "5.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
                if (Confontation)
                {
                    description.Add(tempDesc);
                    tempDesc = "     Confrontation seulement.";
                }
            }
            else if (SubstiCarac != 0)
            {
                tempDesc = "Substitution de caractéristique: ";
                switch (SubstiCarac)
                {
                    case 1:
                        tempDesc += "8.";
                        break;
                    case 2:
                        tempDesc += "10.";
                        break;
                    case 3:
                        tempDesc += "11.";
                        break;
                    case 4:
                        tempDesc += "12.";
                        break;
                    case 5:
                        tempDesc += "14.";
                        break;
                    case 6:
                        tempDesc += "15.";
                        break;
                    case 7:
                        tempDesc += "16.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            description.Add(tempDesc);

            tempDesc = "PP: " + CoutPouvoir.PP + " Niveau: " + CoutPouvoir.Niveau + " Presence: " + CoutPouvoir.Presence + ".";
            description.Add(tempDesc);
        }

        public override string DescriptionPouvoirUneLigne()
        {
            string tempDesc = "Auncun Bonus.";

            if (Initiative != 0)
            {
                tempDesc = "Initiative augmenté, bonus de +";
                switch (Initiative)
                {
                    case 1:
                        tempDesc += "5.";
                        break;
                    case 2:
                        tempDesc += "10.";
                        break;
                    case 3:
                        tempDesc += "15.";
                        break;
                    case 4:
                        tempDesc += "20.";
                        break;
                    case 5:
                        tempDesc += "25.";
                        break;
                    case 6:
                        tempDesc += "30.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (Regeneration != 0)
            {
                tempDesc = "Régénération augmenté: ";
                switch (Regeneration)
                {
                    case 1:
                        tempDesc += "Régénération 4.";
                        break;
                    case 2:
                        tempDesc += "Régénération 8.";
                        break;
                    case 3:
                        tempDesc += "Régénération 12.";
                        break;
                    case 4:
                        tempDesc += "Régénération 14.";
                        break;
                    case 5:
                        tempDesc += "Régénération 16.";
                        break;
                    case 6:
                        tempDesc += "Régénération +1.";
                        break;
                    case 7:
                        tempDesc += "Régénération +2.";
                        break;
                    case 8:
                        tempDesc += "Régénération +4.";
                        break;
                    case 9:
                        tempDesc += "Régénération +6.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (AugDeplacement != 0)
            {
                tempDesc = "Augmentation du déplacement, bonus de +";
                switch (AugDeplacement)
                {
                    case 1:
                        tempDesc += "1.";
                        break;
                    case 2:
                        tempDesc += "2.";
                        break;
                    case 3:
                        tempDesc += "3.";
                        break;
                    case 4:
                        tempDesc += "4.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (AugCompSec != 0)
            {
                tempDesc = "Augmentation des compétences secondaires, bonus de +";
                switch (AugCompSec)
                {
                    case 1:
                        tempDesc += "10.";
                        break;
                    case 2:
                        tempDesc += "25.";
                        break;
                    case 3:
                        tempDesc += "50.";
                        break;
                    case 4:
                        tempDesc += "75.";
                        break;
                    case 5:
                        tempDesc += "100.";
                        break;
                    case 6:
                        tempDesc += "10 Champ complet.";
                        break;
                    case 7:
                        tempDesc += "20 Champ complet.";
                        break;
                    case 8:
                        tempDesc += "30 Champ complet.";
                        break;
                    case 9:
                        tempDesc += "40 Champ complet.";
                        break;
                    case 10:
                        tempDesc += "50 Champ complet.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
                if (AugCompSec > 5)
                {
                    tempDesc += " Au champ " + Competence + ".";
                }
                else
                {
                    tempDesc += " À la compétence " + Competence + ".";
                }
            }
            else if (AugCarac != 0)
            {
                tempDesc = "Augmentation des caractéristiques, bonus de +";
                switch (AugCarac)
                {
                    case 1:
                        tempDesc += "1.";
                        break;
                    case 2:
                        tempDesc += "2.";
                        break;
                    case 3:
                        tempDesc += "3.";
                        break;
                    case 4:
                        tempDesc += "4.";
                        break;
                    case 5:
                        tempDesc += "5.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (SubstiCarac != 0)
            {
                tempDesc = "Substitution de caractéristique: ";
                switch (SubstiCarac)
                {
                    case 1:
                        tempDesc += "8.";
                        break;
                    case 2:
                        tempDesc += "10.";
                        break;
                    case 3:
                        tempDesc += "11.";
                        break;
                    case 4:
                        tempDesc += "12.";
                        break;
                    case 5:
                        tempDesc += "14.";
                        break;
                    case 6:
                        tempDesc += "15.";
                        break;
                    case 7:
                        tempDesc += "16.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            return tempDesc;
        }

        public override void ExportXML(XmlWriter writer)
        {
            throw new NotImplementedException();
        }

        public override void GenererCoutPouvoir()
        {
            CoutPouvoir = new ClassCoutPouvoir(0, 0);

            if (Initiative != 0)
            {
                switch (Initiative)
                {
                    case 1:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 1;
                        break;
                    case 2:
                        CoutPouvoir.PP = 20;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 3:
                        CoutPouvoir.PP = 40;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 4:
                        CoutPouvoir.PP = 80;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 5:
                        CoutPouvoir.PP = 20;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 6:
                        CoutPouvoir.PP = 40;
                        CoutPouvoir.Niveau = 3;
                        break;
                    default:
                        break;
                }
            }
            else if (Regeneration != 0)
            {
                switch (Regeneration)
                {
                    case 1:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 1;
                        break;
                    case 2:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 3:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 4:
                        CoutPouvoir.PP = 150;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 5:
                        CoutPouvoir.PP = 20;
                        CoutPouvoir.Niveau = 4;
                        break;
                    case 6:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 1;
                        break;
                    case 7:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 8:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 9:
                        CoutPouvoir.PP = 150;
                        CoutPouvoir.Niveau = 3;
                        break;
                    default:
                        break;
                }
            }
            else if (AugDeplacement != 0)
            {
                switch (AugDeplacement)
                {
                    case 1:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 1;
                        break;
                    case 2:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 3:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 4:
                        CoutPouvoir.PP = 150;
                        CoutPouvoir.Niveau = 3;
                        break;
                    default:
                        break;
                }
            }
            else if (AugCompSec != 0)
            {
                switch (AugCompSec)
                {
                    case 1:
                        CoutPouvoir.PP = 40;
                        CoutPouvoir.Niveau = 1;
                        break;
                    case 2:
                        CoutPouvoir.PP = 20;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 3:
                        CoutPouvoir.PP = 40;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 4:
                        CoutPouvoir.PP = 20;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 5:
                        CoutPouvoir.PP = 60;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 6:
                        CoutPouvoir.PP = 40;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 7:
                        CoutPouvoir.PP = 20;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 8:
                        CoutPouvoir.PP = 40;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 9:
                        CoutPouvoir.PP = 20;
                        CoutPouvoir.Niveau = 4;
                        break;
                    case 10:
                        CoutPouvoir.PP = 40;
                        CoutPouvoir.Niveau = 5;
                        break;
                    default:
                        break;
                }

            }
            else if (AugCarac != 0)
            {
                switch (AugCarac)
                {
                    case 1:
                        CoutPouvoir.PP = 60;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 2:
                        CoutPouvoir.PP = 80;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 3:
                        CoutPouvoir.PP = 40;
                        CoutPouvoir.Niveau = 4;
                        break;
                    case 4:
                        CoutPouvoir.PP = 120;
                        CoutPouvoir.Niveau = 4;
                        break;
                    case 5:
                        CoutPouvoir.PP = 30;
                        CoutPouvoir.Niveau = 5;
                        break;
                    default:
                        break;
                }
                if (Confontation)
                {
                    CoutPouvoir.PP -= 20;
                    CoutPouvoir.Niveau -= 1;
                }
            }
            else if (SubstiCarac != 0)
            {
                switch (SubstiCarac)
                {
                    case 1:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 2:
                        CoutPouvoir.PP = 20;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 3:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 4:
                        CoutPouvoir.PP = 80;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 5:
                        CoutPouvoir.PP = 20;
                        CoutPouvoir.Niveau = 4;
                        break;
                    case 6:
                        CoutPouvoir.PP = 80;
                        CoutPouvoir.Niveau = 4;
                        break;
                    case 7:
                        CoutPouvoir.PP = 20;
                        CoutPouvoir.Niveau = 5;
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public class ClassTechKi
    {
        public int Niveau;
        public int DI;
        public string Nom;

        public string DescTechKi()
        {
            string tempDesc = "";

            tempDesc = Nom + " Niveau " + Niveau + ".";

            return tempDesc;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ClassFacetteMaitrise : ClassFacette
    {
        public int AccumulationKi;
        public ClassTechKi TechKi;
        public int ReserveKi;
        //mod accunulation ki
        public int CaracLie;
        public bool BadRecuperate;
        public bool RecupOnly;
        //mod Technique de ki
        public int NBUtil;
        public bool Illimite;
        public bool RechargeReduite;
        public int Prep;
        public bool Consommation;
        //mod reserve de ki
        public bool Fuite;
        public bool Filtre;

        public ClassFacetteMaitrise()
        {
            TypePouvoir = TypeFacette.FacetteMaitrise;

            AccumulationKi = 0;
            TechKi = null;
            ReserveKi = 0;
            CaracLie = 0;
            BadRecuperate = false;
            RecupOnly = false;
            NBUtil = -1;
            Illimite = false;
            RechargeReduite = false;
            Prep = 0;
            Consommation = false;
            Fuite = false;
            Filtre = false;

            CoutPouvoir = new ClassCoutPouvoir(0, 0, 0);
        }

        public override void DescriptionPouvoir(List<string> description)
        {
            string tempDesc = "Auncun Bonus.";

            if (TechKi != null)
            {
                tempDesc = "Technique spéciale: ";
                description.Add(tempDesc);
                tempDesc = "        " + TechKi.DescTechKi();
                if (!Illimite)
                {
                    description.Add(tempDesc);
                    tempDesc = "     Utilisable " + (NBUtil + 1) + " fois par jour.";
                }
                else
                {
                    description.Add(tempDesc);
                    tempDesc = "     Utilisation illimité.";
                }
                if (RechargeReduite)
                {
                    description.Add(tempDesc);
                    tempDesc = "     Recharge réduite.";
                }
                if (Prep != 0)
                {
                    description.Add(tempDesc);
                    tempDesc = "     Requiert " + Prep + " round de préparation.";
                }
                if (Consommation)
                {
                    description.Add(tempDesc);
                    tempDesc = "     Consommation de Ki.";
                }
            }
            else if (AccumulationKi != 0)
            {
                tempDesc = "Accumulation de Ki, bonus de +" + AccumulationKi + ".";
                description.Add(tempDesc);
                
                switch (CaracLie)
                {
                    case 1:
                        tempDesc = "     À la caractéristique de Force.";
                        break;
                    case 2:
                        tempDesc = "     À la caractéristique de Constitution.";
                        break;
                    case 3:
                        tempDesc = "     À la caractéristique d'Agilité.";
                        break;
                    case 4:
                        tempDesc = "     À la caractéristique de Dextérité.";
                        break;
                    case 5:
                        tempDesc = "     À la caractéristique de Pouvoir.";
                        break;
                    case 6:
                        tempDesc = "     À la caractéristique de Volonté.";
                        break;
                    case 7:
                        tempDesc = "     Aux caractéristiques physique.";
                        break;
                    case 8:
                        tempDesc = "     Aux caractéristiques d'habileté.";
                        break;
                    case 9:
                        tempDesc = "     Aux caractéristiques animique.";
                        break;
                    default:
                        tempDesc = "     caractéristique(s) hors norme.";
                        break;
                }
                if (BadRecuperate)
                {
                    description.Add(tempDesc);
                    tempDesc = "     Mauvaise récupération.";
                }
                if (RecupOnly)
                {
                    description.Add(tempDesc);
                    tempDesc = "     Récupération seulement.";
                }
            }
            else if (ReserveKi != 0)
            {
                tempDesc = "Réserve de ki de ";
                switch (ReserveKi)
                {
                    case 1:
                        tempDesc += "12.";
                        break;
                    case 2:
                        tempDesc += "24.";
                        break;
                    case 3:
                        tempDesc += "36.";
                        break;
                    case 4:
                        tempDesc += "48.";
                        break;
                    case 5:
                        tempDesc += "60.";
                        break;
                    case 6:
                        tempDesc += "120.";
                        break;
                    case 7:
                        tempDesc += "180.";
                        break;
                    case 8:
                        tempDesc += "240.";
                        break;
                    case 9:
                        tempDesc += "300.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
                if (Fuite)
                {
                    description.Add(tempDesc);
                    tempDesc = "     Fuite de pouvoir.";
                }
                if (Filtre)
                {
                    description.Add(tempDesc);
                    tempDesc = "     Filtre affaiblissant.";
                }
            }
            description.Add(tempDesc);

            tempDesc = "PP: " + CoutPouvoir.PP + " Niveau: " + CoutPouvoir.Niveau + " Presence: " + CoutPouvoir.Presence + ".";
            description.Add(tempDesc);
        }

        public override string DescriptionPouvoirUneLigne()
        {
            string tempDesc = "Auncun Bonus.";

            if (TechKi != null)
            {
                tempDesc = "Technique spéciale: " + TechKi.DescTechKi();
            }
            else if (AccumulationKi != 0)
            {
                tempDesc = "Accumulation de Ki, bonus de +" + AccumulationKi + ".";

                switch (CaracLie)
                {
                    case 1:
                        tempDesc += " À la caractéristique de Force.";
                        break;
                    case 2:
                        tempDesc += " À la caractéristique de Constitution.";
                        break;
                    case 3:
                        tempDesc += " À la caractéristique d'Agilité.";
                        break;
                    case 4:
                        tempDesc += " À la caractéristique de Dextérité.";
                        break;
                    case 5:
                        tempDesc += " À la caractéristique de Pouvoir.";
                        break;
                    case 6:
                        tempDesc += " À la caractéristique de Volonté.";
                        break;
                    case 7:
                        tempDesc += " Aux caractéristiques physique.";
                        break;
                    case 8:
                        tempDesc += " Aux caractéristiques d'habileté.";
                        break;
                    case 9:
                        tempDesc += " Aux caractéristiques animique.";
                        break;
                    default:
                        tempDesc += " caractéristique(s) hors norme.";
                        break;
                }
            }
            else if (ReserveKi != 0)
            {
                tempDesc = "Réserve de ki de ";
                switch (ReserveKi)
                {
                    case 1:
                        tempDesc += "12.";
                        break;
                    case 2:
                        tempDesc += "24.";
                        break;
                    case 3:
                        tempDesc += "36.";
                        break;
                    case 4:
                        tempDesc += "48.";
                        break;
                    case 5:
                        tempDesc += "60.";
                        break;
                    case 6:
                        tempDesc += "120.";
                        break;
                    case 7:
                        tempDesc += "180.";
                        break;
                    case 8:
                        tempDesc += "240.";
                        break;
                    case 9:
                        tempDesc += "300.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            return tempDesc;
        }

        public override void ExportXML(XmlWriter writer)
        {
            throw new NotImplementedException();
        }

        public override void GenererCoutPouvoir()
        {
            CoutPouvoir = new ClassCoutPouvoir(0, 0);

            if (TechKi != null)
            {
                switch (TechKi.Niveau)
                {
                    case 1:
                        CoutPouvoir.PP = TechKi.DI *4;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 2:
                        CoutPouvoir.PP = TechKi.DI * 4;
                        CoutPouvoir.Niveau = 4;
                        break;
                    default:
                        break;
                }
                if (!Illimite)
                {
                    CoutPouvoir.PP += (20 * NBUtil);
                }
                else
                {
                    CoutPouvoir.PP += 50;
                    CoutPouvoir.Niveau += 1;
                }
                if (RechargeReduite)
                {
                    CoutPouvoir.PP += 50;
                }
                if (Prep != 0)
                {
                    CoutPouvoir.PP -= (5 * Prep);
                }
                if (Consommation)
                {
                    CoutPouvoir.PP -= 50;
                }
            }
            else if (AccumulationKi != 0)
            {
                switch (AccumulationKi)
                {
                    case 1:
                        CoutPouvoir.PP = 150;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 2:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 3:
                        CoutPouvoir.PP = 150;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 4:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 4;
                        break;
                    case 5:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 5;
                        break;
                    default:
                        break;
                }
                switch (CaracLie)
                {
                    case 7:
                        CoutPouvoir.PP += 50;
                        break;
                    case 8:
                        CoutPouvoir.PP += 50;
                        break;
                    case 9:
                        CoutPouvoir.PP += 50;
                        break;
                    default:
                        
                        break;
                }
                if (BadRecuperate)
                {
                    CoutPouvoir.PP -= 10;
                }
                if (RecupOnly)
                {
                    CoutPouvoir.Niveau -= 1;
                }
            }
            else if (ReserveKi != 0)
            {
                switch (ReserveKi)
                {
                    case 1:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 1;
                        break;
                    case 2:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 3:
                        CoutPouvoir.PP = 150;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 4:
                        CoutPouvoir.PP = 250;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 5:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 6:
                        CoutPouvoir.PP = 150;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 7:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 4;
                        break;
                    case 8:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 4;
                        break;
                    case 9:
                        CoutPouvoir.PP = 250;
                        CoutPouvoir.Niveau = 4;
                        break;
                    default:
                        break;
                }
                if (Fuite)
                {
                    CoutPouvoir.PP -= 40;
                }
                if (Filtre)
                {
                    CoutPouvoir.PP -= 25;
                }
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ClassEffetMystique : ClassFacette
    {
        public int Effet;
        public int Resistance;
        public int Condition;
        public bool Limite;

        public ClassEffetMystique()
        {
            TypePouvoir = TypeFacette.FacetteEsoterique;
            SubType = SubTypeFacette.EffetMystique;

            Effet = 0;
            Resistance = 0;
            Condition = 0;
            Limite = false;

            CoutPouvoir = new ClassCoutPouvoir(0, 0, 0);
        }

        public override void DescriptionPouvoir(List<string> description)
        {
            string tempDesc = "Auncun Bonus.";

            tempDesc = "Effet mystique:";
            description.Add(tempDesc);
            tempDesc = "     Effet: ";
            switch (Effet)
            {
                case 1:
                    tempDesc += "Peur.";
                    break;
                case 2:
                    tempDesc += "Terreur.";
                    break;
                case 3:
                    tempDesc += "Douleur.";
                    break;
                case 4:
                    tempDesc += "Douleur extrême.";
                    break;
                case 5:
                    tempDesc += "Faiblesse.";
                    break;
                case 6:
                    tempDesc += "Paralysie partielle.";
                    break;
                case 7:
                    tempDesc += "Paralysie totale.";
                    break;
                case 8:
                    tempDesc += "Colère.";
                    break;
                case 9:
                    tempDesc += "Cécité.";
                    break;
                case 10:
                    tempDesc += "Surdité.";
                    break;
                case 11:
                    tempDesc += "Mutisme.";
                    break;
                case 12:
                    tempDesc += "Fascination.";
                    break;
                case 13:
                    tempDesc += "Dégâts simples.";
                    break;
                case 14:
                    tempDesc += "Dégâts doubles.";
                    break;
                case 15:
                    tempDesc += "Inconscience.";
                    break;
                case 16:
                    tempDesc += "Domination.";
                    break;
                case 17:
                    tempDesc += "Mort.";
                    break;
                case 18:
                    tempDesc += "Folie.";
                    break;
                case 19:
                    tempDesc += "Vieillesse.";
                    break;
                case 20:
                    tempDesc += "Malus à toute action.";
                    break;
                case 21:
                    tempDesc += "Destruction de caractéristiques.";
                    break;
                case 22:
                    tempDesc += "Drain (moitié).";
                    break;
                case 23:
                    tempDesc += "Drain (complet).";
                    break;
                default:
                    tempDesc = "Effet hors norme.";
                    break;
            }
            description.Add(tempDesc);
            tempDesc = "     Resistance: ";
            switch (Resistance)
            {
                case 0:
                    tempDesc += "RMys 40.";
                    break;
                case 1:
                    tempDesc += "RMys 80.";
                    break;
                case 2:
                    tempDesc += "RMys 100.";
                    break;
                case 3:
                    tempDesc += "RMys 120.";
                    break;
                case 4:
                    tempDesc += "RMys 140.";
                    break;
                case 5:
                    tempDesc += "RMys 180.";
                    break;
                case 6:
                    tempDesc += "RMys 200.";
                    break;
                default:
                    tempDesc += "Bonus hors norme.";
                    break;
            }
            description.Add(tempDesc);
            tempDesc = "     Condition: ";
            switch (Condition)
            {
                case 0:
                    tempDesc += "Par les dégâts.";
                    break;
                case 1:
                    tempDesc += "Par le contact.";
                    break;
                case 2:
                    tempDesc += "Par le son.";
                    break;
                case 3:
                    tempDesc += "Par la vue.";
                    break;
                case 4:
                    tempDesc += "Par l'odeur.";
                    break;
                case 5:
                    tempDesc += "Zone (5 mètres).";
                    break;
                case 6:
                    tempDesc += "Zone (10 mètres).";
                    break;
                case 7:
                    tempDesc += "Zone (25 mètres).";
                    break;
                case 8:
                    tempDesc += "Zone (50 mètres).";
                    break;
                default:
                    tempDesc = "Condition hors norme.";
                    break;
            }
            if (Limite)
            {
                description.Add(tempDesc);
                tempDesc = "       Temps limité.";
                description.Add(tempDesc);
            }
        }

        public override string DescriptionPouvoirUneLigne()
        {
            string tempDesc = "Effet mystique: ";

            switch (Effet)
            {
                case 1:
                    tempDesc += "Peur.";
                    break;
                case 2:
                    tempDesc += "Terreur.";
                    break;
                case 3:
                    tempDesc += "Douleur.";
                    break;
                case 4:
                    tempDesc += "Douleur extrême.";
                    break;
                case 5:
                    tempDesc += "Faiblesse.";
                    break;
                case 6:
                    tempDesc += "Paralysie partielle.";
                    break;
                case 7:
                    tempDesc += "Paralysie totale.";
                    break;
                case 8:
                    tempDesc += "Colère.";
                    break;
                case 9:
                    tempDesc += "Cécité.";
                    break;
                case 10:
                    tempDesc += "Surdité.";
                    break;
                case 11:
                    tempDesc += "Mutisme.";
                    break;
                case 12:
                    tempDesc += "Fascination.";
                    break;
                case 13:
                    tempDesc += "Dégâts simples.";
                    break;
                case 14:
                    tempDesc += "Dégâts doubles.";
                    break;
                case 15:
                    tempDesc += "Inconscience.";
                    break;
                case 16:
                    tempDesc += "Domination.";
                    break;
                case 17:
                    tempDesc += "Mort.";
                    break;
                case 18:
                    tempDesc += "Folie.";
                    break;
                case 19:
                    tempDesc += "Vieillesse.";
                    break;
                case 20:
                    tempDesc += "Malus à toute action.";
                    break;
                case 21:
                    tempDesc += "Destruction de caractéristiques.";
                    break;
                case 22:
                    tempDesc += "Drain (moitié).";
                    break;
                case 23:
                    tempDesc += "Drain (complet).";
                    break;
                default:
                    tempDesc = "Effet hors norme.";
                    break;
            }
            tempDesc += " Resistance: ";
            switch (Resistance)
            {
                case 0:
                    tempDesc += "RMys 40.";
                    break;
                case 1:
                    tempDesc += "RMys 80.";
                    break;
                case 2:
                    tempDesc += "RMys 100.";
                    break;
                case 3:
                    tempDesc += "RMys 120.";
                    break;
                case 4:
                    tempDesc += "RMys 140.";
                    break;
                case 5:
                    tempDesc += "RMys 180.";
                    break;
                case 6:
                    tempDesc += "RMys 200.";
                    break;
                default:
                    tempDesc += "Bonus hors norme.";
                    break;
            }
            tempDesc += " Condition: ";
            switch (Condition)
            {
                case 0:
                    tempDesc += "Par les dégâts.";
                    break;
                case 1:
                    tempDesc += "Par le contact.";
                    break;
                case 2:
                    tempDesc += "Par le son.";
                    break;
                case 3:
                    tempDesc += "Par la vue.";
                    break;
                case 4:
                    tempDesc += "Par l'odeur.";
                    break;
                case 5:
                    tempDesc += "Zone (5 mètres).";
                    break;
                case 6:
                    tempDesc += "Zone (10 mètres).";
                    break;
                case 7:
                    tempDesc += "Zone (25 mètres).";
                    break;
                case 8:
                    tempDesc += "Zone (50 mètres).";
                    break;
                default:
                    tempDesc = "Condition hors norme.";
                    break;
            }
            return tempDesc;
        }

        public override void ExportXML(XmlWriter writer)
        {
            throw new NotImplementedException();
        }

        public override void GenererCoutPouvoir()
        {
            CoutPouvoir = new ClassCoutPouvoir(0, 0);

            switch (Effet)
            {
                case 1:
                    CoutPouvoir.PP = 150;
                    CoutPouvoir.Niveau = 2;
                    break;
                case 2:
                    CoutPouvoir.PP = 150;
                    CoutPouvoir.Niveau = 3;
                    break;
                case 3:
                    CoutPouvoir.PP = 120;
                    CoutPouvoir.Niveau = 2;
                    break;
                case 4:
                    CoutPouvoir.PP = 40;
                    CoutPouvoir.Niveau = 3;
                    break;
                case 5:
                    CoutPouvoir.PP = 80;
                    CoutPouvoir.Niveau = 2;
                    break;
                case 6:
                    CoutPouvoir.PP = 80;
                    CoutPouvoir.Niveau = 3;
                    break;
                case 7:
                    CoutPouvoir.PP = 20;
                    CoutPouvoir.Niveau = 4;
                    break;
                case 8:
                    CoutPouvoir.PP = 100;
                    CoutPouvoir.Niveau = 2;
                    break;
                case 9:
                    CoutPouvoir.PP = 80;
                    CoutPouvoir.Niveau = 3;
                    break;
                case 10:
                    CoutPouvoir.PP = 120;
                    CoutPouvoir.Niveau = 2;
                    break;
                case 11:
                    CoutPouvoir.PP = 60;
                    CoutPouvoir.Niveau = 2;
                    break;
                case 12:
                    CoutPouvoir.PP = 40;
                    CoutPouvoir.Niveau = 3;
                    break;
                case 13:
                    CoutPouvoir.PP = 80;
                    CoutPouvoir.Niveau = 2;
                    break;
                case 14:
                    CoutPouvoir.PP = 40;
                    CoutPouvoir.Niveau = 3;
                    break;
                case 15:
                    CoutPouvoir.PP = 200;
                    CoutPouvoir.Niveau = 3;
                    break;
                case 16:
                    CoutPouvoir.PP = 40;
                    CoutPouvoir.Niveau = 4;
                    break;
                case 17:
                    CoutPouvoir.PP = 80;
                    CoutPouvoir.Niveau = 4;
                    break;
                case 18:
                    CoutPouvoir.PP = 100;
                    CoutPouvoir.Niveau = 3;
                    break;
                case 19:
                    CoutPouvoir.PP = 120;
                    CoutPouvoir.Niveau = 3;
                    break;
                case 20:
                    CoutPouvoir.PP = 80;
                    CoutPouvoir.Niveau = 3;
                    break;
                case 21:
                    CoutPouvoir.PP = 100;
                    CoutPouvoir.Niveau = 3;
                    break;
                case 22:
                    CoutPouvoir.PP = 100;
                    CoutPouvoir.Niveau = 3;
                    break;
                case 23:
                    CoutPouvoir.PP = 160;
                    CoutPouvoir.Niveau = 3;
                    break;
                default:
                    break;
            }
            switch (Resistance)
            {
                case 1:
                    CoutPouvoir.PP += 10;
                    break;
                case 2:
                    CoutPouvoir.PP += 20;
                    break;
                case 3:
                    CoutPouvoir.PP += 40;
                    break;
                case 4:
                    CoutPouvoir.PP += 60;
                    break;
                case 5:
                    CoutPouvoir.PP += 20;
                    CoutPouvoir.Niveau += 1;
                    break;
                case 6:
                    CoutPouvoir.PP += 60;
                    CoutPouvoir.Niveau += 1;
                    break;
                default:
                    break;
            }
            switch (Condition)
            {
                case 1:
                    CoutPouvoir.PP += 20;
                    break;
                case 2:
                    CoutPouvoir.PP += 40;
                    break;
                case 3:
                    CoutPouvoir.PP += 60;
                    break;
                case 4:
                    CoutPouvoir.PP += 40;
                    break;
                case 5:
                    CoutPouvoir.PP += 80;
                    break;
                case 6:
                    CoutPouvoir.PP += 120;
                    break;
                case 7:
                    CoutPouvoir.PP += 150;
                    break;
                case 8:
                    CoutPouvoir.PP += 20;
                    CoutPouvoir.Niveau += 1;
                    break;
                default:
                    break;
            }
            if (Limite)
            {
                CoutPouvoir.PP -= 20;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ClassFacetteEsoterique : ClassFacette
    {
        public int Prothese,
            AlterationDestion,
            Dissimulation,
            Vision,
            EffetMineur,
            Ego,
            Portal;
        public bool Toucher,
            ArmeNauturel;
        //mod Destin
        public bool UtilReduite;
        public string Condition;
        //mod ego
        public bool Communication,
            Genie,
            PersoDetermine,
            Ordre;
        //mod portail
        public bool Divise;
        public int NBUtil;

        public ClassFacetteEsoterique()
        {
            TypePouvoir = TypeFacette.FacetteEsoterique;

            Prothese = 0;
            AlterationDestion = 0;
            Dissimulation = 0;
            Vision = 0;
            EffetMineur = 0;
            Ego = 0;
            Portal = 0;
            //mod prothese
            Toucher = false;
            ArmeNauturel = false;
            //mod Destin
            UtilReduite = false;
            Condition = "";
            //mod ego
            Communication = false;
            Genie = false;
            PersoDetermine = false;
            Ordre = false;
            //mod portail
            Divise = false;
            NBUtil = 0;

            CoutPouvoir = new ClassCoutPouvoir(0, 0, 0);
        }

        public override void DescriptionPouvoir(List<string> description)
        {
            string tempDesc = "";

            if (Prothese != 0)
            {
                tempDesc = "Prothèse, ";
                switch (Prothese)
                {
                    case 1:
                        tempDesc += "Membre inférieur.";
                        break;
                    case 2:
                        tempDesc += "Membre parfait.";
                        break;
                    case 3:
                        tempDesc += "Membre supérieur.";
                        break;
                    case 4:
                        tempDesc += "Organe sensitif inférieur.";
                        break;
                    case 5:
                        tempDesc += "Organe sensitif parfait.";
                        break;
                    case 6:
                        tempDesc += "Organe sensitif supérieur.";
                        break;
                    case 7:
                        tempDesc += "Organe interne inférieur.";
                        break;
                    case 8:
                        tempDesc += "Organe interne parfait.";
                        break;
                    case 9:
                        tempDesc += "Organe interne supérieur.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }

                if (Prothese <= 3)
                {
                    if (Toucher)
                    {
                        description.Add(tempDesc);
                        tempDesc = "     Toucher.";
                    }
                    if (ArmeNauturel)
                    {
                        description.Add(tempDesc);
                        tempDesc = "     Arme naturel.";
                    }
                }
            }
            else if (AlterationDestion != 0)
            {
                tempDesc = "Altération du destin, ";
                switch (AlterationDestion)
                {
                    case 1:
                        tempDesc += "Réduction des maladresses.";
                        break;
                    case 2:
                        tempDesc += "Amélioration critique.";
                        break;
                    case 3:
                        tempDesc += "Doubles.";
                        break;
                    case 4:
                        tempDesc += "Altération existentielle.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
                if (UtilReduite)
                {
                    description.Add(tempDesc);
                    tempDesc = "     Utilisation réduite: " + Condition;
                }
            }
            else if (Dissimulation != 0)
            {
                tempDesc = "Dissimulation amélioré: ";
                switch (Dissimulation)
                {
                    case 1:
                        tempDesc += "Absurde";
                        break;
                    case 2:
                        tempDesc += "Quasiment impossible.";
                        break;
                    case 3:
                        tempDesc += "Impossible.";
                        break;
                    case 4:
                        tempDesc += "Surhumain.";
                        break;
                    case 5:
                        tempDesc += "Zen.";
                        break;
                    case 6:
                        tempDesc += "Indétectable.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (Vision != 0)
            {
                tempDesc = "Moyens spéciaux de vision: ";
                switch (Vision)
                {
                    case 1:
                        tempDesc += "Vision nocturne.";
                        break;
                    case 2:
                        tempDesc += "Vision nocturne totale.";
                        break;
                    case 3:
                        tempDesc += "Voir la magie.";
                        break;
                    case 4:
                        tempDesc += "Voir les matrices.";
                        break;
                    case 5:
                        tempDesc += "Voir les esprits.";
                        break;
                    case 6:
                        tempDesc += "Voir le surnaturel.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (Ego != 0)
            {
                tempDesc = "Ego: ";
                switch (Ego)
                {
                    case 1:
                        tempDesc += "Ego simple.";
                        break;
                    case 2:
                        tempDesc += "Ego complexe.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
                if (Communication)
                {
                    description.Add(tempDesc);
                    tempDesc = "     Communication.";
                }
                if (Genie)
                {
                    description.Add(tempDesc);
                    tempDesc = "     Génie.";
                }
                if (PersoDetermine)
                {
                    description.Add(tempDesc);
                    tempDesc = "     Personalité déterminé.";
                }
                if (Ordre)
                {
                    description.Add(tempDesc);
                    tempDesc = "     Ordre.";
                }
            }
            else if (Portal != 0)
            {
                tempDesc = "Créateur de portails: ";
                switch (Portal)
                {
                    case 1:
                        tempDesc += "Porte vers la veille[Anima]/Plan élémentaire[D&D] (Voile faibe).";
                        break;
                    case 2:
                        tempDesc += "Porte vers la veille[Anima]/Plan[D&D].";
                        break;
                    case 3:
                        tempDesc += "Portail (lieu déterminé).";
                        break;
                    case 4:
                        tempDesc += "Portail fixe.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
                if (Divise)
                {
                    description.Add(tempDesc);
                    tempDesc = "     Objet divisé.";
                }
                if (NBUtil > 0)
                {
                    description.Add(tempDesc);
                    tempDesc = "     ";
                    switch (NBUtil)
                    {
                        case 1:
                            tempDesc += "5";
                            break;
                        case 2:
                            tempDesc += "3";
                            break;
                        case 3:
                            tempDesc += "1";
                            break;
                        default:
                            tempDesc = "Bonus hors norme.";
                            break;
                    }
                    tempDesc += "fois par jour";
                }
            }
            else if (EffetMineur != 0)
            {
                tempDesc = "Effet mineur: ";
                switch (Portal)
                {
                    case 1:
                        tempDesc += "Occultation.";
                        break;
                    case 2:
                        tempDesc += "Transfert.";
                        break;
                    case 3:
                        tempDesc += "Maestria.";
                        break;
                    case 4:
                        tempDesc += "Indestructibilité.";
                        break;
                    case 5:
                        tempDesc += "Autodestruction.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }

            if (tempDesc.Count() != 0)
            {
                description.Add(tempDesc);
            }

            tempDesc = "PP: " + CoutPouvoir.PP + " Niveau: " + CoutPouvoir.Niveau + " Presence: " + CoutPouvoir.Presence + ".";
            description.Add(tempDesc);
        }

        public override string DescriptionPouvoirUneLigne()
        {
            string tempDesc = "";

            if (Prothese != 0)
            {
                tempDesc = "Prothèse, ";
                switch (Prothese)
                {
                    case 1:
                        tempDesc += "Membre inférieur.";
                        break;
                    case 2:
                        tempDesc += "Membre parfait.";
                        break;
                    case 3:
                        tempDesc += "Membre supérieur.";
                        break;
                    case 4:
                        tempDesc += "Organe sensitif inférieur.";
                        break;
                    case 5:
                        tempDesc += "Organe sensitif parfait.";
                        break;
                    case 6:
                        tempDesc += "Organe sensitif supérieur.";
                        break;
                    case 7:
                        tempDesc += "Organe interne inférieur.";
                        break;
                    case 8:
                        tempDesc += "Organe interne parfait.";
                        break;
                    case 9:
                        tempDesc += "Organe interne supérieur.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (AlterationDestion != 0)
            {
                tempDesc = "Altération du destin, ";
                switch (AlterationDestion)
                {
                    case 1:
                        tempDesc += "Réduction des maladresses.";
                        break;
                    case 2:
                        tempDesc += "Amélioration critique.";
                        break;
                    case 3:
                        tempDesc += "Doubles.";
                        break;
                    case 4:
                        tempDesc += "Altération existentielle.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (Dissimulation != 0)
            {
                tempDesc = "Dissimulation amélioré: ";
                switch (Dissimulation)
                {
                    case 1:
                        tempDesc += "Absurde";
                        break;
                    case 2:
                        tempDesc += "Quasiment impossible.";
                        break;
                    case 3:
                        tempDesc += "Impossible.";
                        break;
                    case 4:
                        tempDesc += "Surhumain.";
                        break;
                    case 5:
                        tempDesc += "Zen.";
                        break;
                    case 6:
                        tempDesc += "Indétectable.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (Vision != 0)
            {
                tempDesc = "Moyens spéciaux de vision: ";
                switch (Vision)
                {
                    case 1:
                        tempDesc += "Vision nocturne.";
                        break;
                    case 2:
                        tempDesc += "Vision nocturne totale.";
                        break;
                    case 3:
                        tempDesc += "Voir la magie.";
                        break;
                    case 4:
                        tempDesc += "Voir les matrices.";
                        break;
                    case 5:
                        tempDesc += "Voir les esprits.";
                        break;
                    case 6:
                        tempDesc += "Voir le surnaturel.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (Ego != 0)
            {
                tempDesc = "Ego: ";
                switch (Ego)
                {
                    case 1:
                        tempDesc += "Ego simple.";
                        break;
                    case 2:
                        tempDesc += "Ego complexe.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (Portal != 0)
            {
                tempDesc = "Créateur de portails: ";
                switch (Portal)
                {
                    case 1:
                        tempDesc += "Porte vers la veille[Anima]/Plan élémentaire[D&D] (Voile faibe).";
                        break;
                    case 2:
                        tempDesc += "Porte vers la veille[Anima]/Plan[D&D].";
                        break;
                    case 3:
                        tempDesc += "Portail (lieu déterminé).";
                        break;
                    case 4:
                        tempDesc += "Portail fixe.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            else if (EffetMineur != 0)
            {
                tempDesc = "Effet mineur: ";
                switch (Portal)
                {
                    case 1:
                        tempDesc += "Occultation.";
                        break;
                    case 2:
                        tempDesc += "Transfert.";
                        break;
                    case 3:
                        tempDesc += "Maestria.";
                        break;
                    case 4:
                        tempDesc += "Indestructibilité.";
                        break;
                    case 5:
                        tempDesc += "Autodestruction.";
                        break;
                    default:
                        tempDesc = "Bonus hors norme.";
                        break;
                }
            }
            return tempDesc;

        }

        public override void ExportXML(XmlWriter writer)
        {
            throw new NotImplementedException();
        }

        public override void GenererCoutPouvoir()
        {
            CoutPouvoir = new ClassCoutPouvoir(0, 0);

            if (Prothese != 0)
            {
                switch (Prothese)
                {
                    case 1:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 2:
                        CoutPouvoir.PP = 60;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 3:
                        CoutPouvoir.PP = 200;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 4:
                        CoutPouvoir.PP = 80;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 5:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 6:
                        CoutPouvoir.PP = 150;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 7:
                        CoutPouvoir.PP = 120;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 8:
                        CoutPouvoir.PP = 80;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 9:
                        CoutPouvoir.PP = 120;
                        CoutPouvoir.Niveau = 3;
                        break;
                    default:
                        break;
                }

                if (Prothese <= 3)
                {
                    if (Toucher)
                    {
                        CoutPouvoir.PP += 20;
                    }
                    if (ArmeNauturel)
                    {
                        CoutPouvoir.PP += 30;
                    }
                }
            }
            else if (AlterationDestion != 0)
            {
                switch (AlterationDestion)
                {
                    case 1:
                        CoutPouvoir.PP = 150;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 2:
                        CoutPouvoir.PP = 75;
                        CoutPouvoir.Niveau = 4;
                        break;
                    case 3:
                        CoutPouvoir.PP = 150;
                        CoutPouvoir.Niveau = 4;
                        break;
                    case 4:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 4;
                        break;
                    default:
                        break;
                }
                if (UtilReduite)
                {
                    CoutPouvoir.PP -= 20;
                }
            }
            else if (Vision != 0)
            {
                switch (Vision)
                {
                    case 1:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 1;
                        break;
                    case 2:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 3:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 4:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 5:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 6:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 3;
                        break;
                    default:
                        break;
                }
            }
            else if (Ego != 0)
            {
                switch (Ego)
                {
                    case 1:
                        CoutPouvoir.PP = 60;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 2:
                        CoutPouvoir.PP = 120;
                        CoutPouvoir.Niveau = 3;
                        break;
                    default:
                        break;
                }
                if (Communication)
                {
                    CoutPouvoir.PP += 20;
                }
                if (Genie)
                {
                    CoutPouvoir.PP += 60;
                }
                if (PersoDetermine)
                {
                    CoutPouvoir.PP += 20;
                }
                if (Ordre)
                {
                    CoutPouvoir.PP += 20;
                }
            }
            else if (Portal != 0)
            {
                switch (Portal)
                {
                    case 1:
                        CoutPouvoir.PP = 150;
                        CoutPouvoir.Niveau = 2;
                        break;
                    case 2:
                        CoutPouvoir.PP = 150;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 3:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 4:
                        CoutPouvoir.PP = 30;
                        CoutPouvoir.Niveau = 4;
                        break;
                    default:
                        break;
                }
                if (Divise)
                {
                    CoutPouvoir.PP = 11;
                }
                if (NBUtil > 0)
                {
                    switch (NBUtil)
                    {
                        case 1:
                            CoutPouvoir.PP -= 10;
                            break;
                        case 2:
                            CoutPouvoir.PP -= 20;
                            break;
                        case 3:
                            CoutPouvoir.PP -= 30;
                            break;
                        default:
                            break;
                    }
                }
            }
            else if (EffetMineur != 0)
            {
                switch (Portal)
                {
                    case 1:
                        CoutPouvoir.PP = 100;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 2:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 3;
                        break;
                    case 3:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 1;
                        break;
                    case 4:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 4;
                        break;
                    case 5:
                        CoutPouvoir.PP = 50;
                        CoutPouvoir.Niveau = 1;
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Génère le coût pour le pouvoir dissimulation
        /// </summary>
        /// <param name="artefact"></param>
        /// <returns></returns>
        public void GenererCoutPouvoir(ClassArtefact artefact)
        {
            CoutPouvoir = new ClassCoutPouvoir(0, 0);

            if (Dissimulation != 0)
            {
                switch (Dissimulation)
                {
                    case 1:
                        CoutPouvoir.PP = 20;
                        break;
                    case 2:
                        CoutPouvoir.PP = 40;
                        break;
                    case 3:
                        CoutPouvoir.PP = 80;
                        break;
                    case 4:
                        CoutPouvoir.PP = 120;
                        break;
                    case 5:
                        CoutPouvoir.PP = 160;
                        break;
                    case 6:
                        CoutPouvoir.PP = 100;
                        break;
                    default:
                        break;
                }
                int tmpNiveau = 0;

                foreach (ClassFacette pouvoir in artefact.Pouvoirs)
                {
                    if (pouvoir.CoutPouvoir.Niveau > tmpNiveau)
                        tmpNiveau = pouvoir.CoutPouvoir.Niveau;
                }
                CoutPouvoir.Niveau = tmpNiveau;
            }
        }
    }

    /// <summary>
    /// Pour les pouvoirs autre
    /// </summary>
    public class ClassAutrePouvoir : ClassFacette
    {


        public override void DescriptionPouvoir(List<string> description)
        {
            throw new NotImplementedException();
        }

        public override string DescriptionPouvoirUneLigne()
        {
            throw new NotImplementedException();
        }

        public override void ExportXML(XmlWriter writer)
        {
            throw new NotImplementedException();
        }

        public override void GenererCoutPouvoir()
        {
            throw new NotImplementedException();
        }
    }
}
