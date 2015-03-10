using System.Collections.Generic;
using System.Linq;
using apitool.core.Builders.Criteria;
using apitool.core.Models.Criteria;
using apitool.core.Models.Parameters;

namespace apitool.core.Providers
{
    public class CallCriteriaProvider : ICallCriteriaProvider
    {
        private readonly Dictionary<string, ICallCriteriaBuilder> _listOfCriteriaBuilders = new Dictionary<string, ICallCriteriaBuilder>();

        public Dictionary<string, ICallCriteriaBuilder> ListOfCriteriaBuilders
        {
            get
            {
                if (!_listOfCriteriaBuilders.Any())
                {
                    _listOfCriteriaBuilders.Add("login", new LoginCriteriaBuilder());
                    _listOfCriteriaBuilders.Add("myreservations", new MyReservationsCriteriaBuilder());
                    _listOfCriteriaBuilders.Add("reservationstatus", new ReservationStatusCriteriaBuilder());
                    _listOfCriteriaBuilders.Add("getfavorites", new GetFavoritesCriteriaBuilder());
                    _listOfCriteriaBuilders.Add("addfavorite", new AddFavoriteCriteriaBuilder());
                    _listOfCriteriaBuilders.Add("removefavorite", new RemoveFavoriteCriteriaBuilder());
                    _listOfCriteriaBuilders.Add("register", new RegisterCriteriaBuilder());
                    _listOfCriteriaBuilders.Add("offerdetails", new OfferDetailsCriteriaBuilder());
                    _listOfCriteriaBuilders.Add("restaurant", new RestaurantCriteriaBuilder());
                    _listOfCriteriaBuilders.Add("searchrestaurantids", new SearchRestaurantIdsCriteriaBuilder());
                    _listOfCriteriaBuilders.Add("searchregions", new SearchRegionsCriteriaBuilder());
                    _listOfCriteriaBuilders.Add("localrestaurantsbyname", new LocalRestaurantsByNameCriteriaBuilder());
                    _listOfCriteriaBuilders.Add("table", new TableCriteriaBuilder());
                    _listOfCriteriaBuilders.Add("geosearch", new GeoSearchCriteriaBuilder());
                    _listOfCriteriaBuilders.Add("slotlock", new SlotLockCriteriaBuilder());
                    _listOfCriteriaBuilders.Add("make", new MakeCriteriaBuilder());
                    _listOfCriteriaBuilders.Add("change", new ChangeCriteriaBuilder());
                    _listOfCriteriaBuilders.Add("cancel", new CancelCriteriaBuilder());
                }

                return _listOfCriteriaBuilders;
            }
        }

        public ICallCriteria Build(string key, CallParameters parameters)
        {
            return ListOfCriteriaBuilders[key].Build(parameters);
        }
    }
}