from api.models.series import Series
from api.models.set import Set
from django.db import models

class Card(models.Model):
    categoty = models.CharField(max_length=255)
    id = models.CharField(max_length=50, primary_key=True)
    illustrator = models.CharField(max_length=255)
    image = models.ImageField(null=True, blank=True)
    local_id = models.IntegerField()
    name = models.CharField(max_length=255)
    rarity = models.CharField(max_length=255)
    
    variant_first_edition = models.BooleanField()
    variant_holo = models.BooleanField()
    variant_normal = models.BooleanField()
    variant_reverse = models.BooleanField()
    variant_w_promo = models.BooleanField()
    
    
    
    
    
    
    from_series = models.ForeignKey(Series, on_delete=models.CASCADE)
    from_set = models.ForeignKey(Set, on_delete=models.CASCADE)

