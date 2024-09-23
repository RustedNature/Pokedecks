from django.db import models

from api.models.series import Series

class Set(models.Model):
    id = models.CharField(max_length=50, primary_key=True)
    name = models.CharField(max_length=255)
    set_logo = models.ImageField(null=True, blank=True)
    set_symbol = models.ImageField(null=True, blank=True)
    card_count_printed_total = models.IntegerField() # number of cards in the set excluding secrect rares
    card_count_total = models.IntegerField() # total number of cards in the set

    from_series = models.ForeignKey(Series, on_delete=models.CASCADE) 
    
    #TODO: follow this link https://docs.pokemontcg.io/api-reference/sets/set-object
    
    def __str__(self):
        return self.name