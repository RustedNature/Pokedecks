from django.db import models

from api.models.series import Series

class Set(models.Model):
    id = models.CharField(max_length=50, primary_key=True)
    name = models.CharField(max_length=255)
    set_logo = models.ImageField(null=True, blank=True)
    set_symbol = models.ImageField(null=True, blank=True)
    card_count_first_edition = models.IntegerField()
    card_count_holo = models.IntegerField()
    card_count_normal = models.IntegerField()
    card_count_official = models.IntegerField()
    card_count_reverse = models.IntegerField()
    card_count_total = models.IntegerField()

    from_series = models.ForeignKey(Series, on_delete=models.CASCADE) 
    
    def __str__(self):
        return self.name