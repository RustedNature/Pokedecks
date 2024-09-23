from django.urls import path
from .views import get_series, create_series, delete_series, update_series
from .views import get_cards, create_card, delete_card, update_card
from .views import get_sets, create_set, delete_set, update_set

urlpatterns = [
    ##########################SERIES##########################
    path("series/", get_series, name="get_series"),  # GET
    path("series/create/", create_series, name="create_series"),  # POST
    path("series/delete/<str:id>/", delete_series, name="delete_series"),  # DELETE
    path("series/update/<str:id>/", update_series, name="update_series"), # PUT
    ##########################SETS##########################
    path("sets/", get_sets, name="get_sets"),  # GET
    path("sets/create/", create_set, name="create_set"),  # POST
    path("sets/delete/<str:id>/", delete_set, name="delete_set"),  # DELETE
    path("sets/update/<str:id>/", update_set, name="update_set"), # PUT
    ##########################CARDS##########################
    path("cards/", get_cards, name="get_cards"),  # GET
    path("cards/create/", create_card, name="create_card"),  # POST
    path("cards/delete/<str:id>/", delete_card, name="delete_card"),  # DELETE
    path("cards/update/<str:id>/", update_card, name="update_card"), # PUT
]
