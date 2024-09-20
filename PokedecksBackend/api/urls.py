from django.urls import path
from .views import get_series, create_series, delete_series

urlpatterns = [
    path("series/", get_series, name="get_series"),  # GET
    path("series/create/", create_series, name="create_series"),  # POST
    path("series/delete/<str:id>/", delete_series, name="delete_series"),  # DELETE
]
