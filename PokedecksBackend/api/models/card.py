from api.models import  Set, Rarity, SuperType, SubType, Type, Ability, Attack

from django.db import models as m
 
class Card(m.Model):
    id = m.CharField(max_length=50, primary_key=True)
    name = m.CharField(max_length=255)
    supertype = m.ForeignKey(SuperType, on_delete=m.CASCADE)
    subtypes = m.ManyToManyField(SubType)
    hp = m.IntegerField()
    types = m.ManyToManyField(Type)
    evolves_from = m.CharField(max_length=75, null=True)
    abilities = m.ManyToManyField(Ability)
    attacks = m.ManyToManyField(Attack)
    weaknesses = m.JSONField()
    retreat_cost = m.JSONField()
    convert_retreat_cost = m.IntegerField()
    from_set = m.ForeignKey(Set, on_delete=m.CASCADE)
    card_number = m.IntegerField()
    illustrator = m.CharField(max_length=255)
    rarity = m.ForeignKey(Rarity, on_delete=m.CASCADE)
    flavor_text = m.CharField(max_length=255)
    national_pokedex_numbers = m.JSONField()
    legalities = m.JSONField()
    small_image = m.ImageField(null=True)
    large_image = m.ImageField(null=True)
    
    #categoty = m.CharField(max_length=255)
    
    #local_id = m.IntegerField()
    #variant_first_edition = m.BooleanField()
    #variant_holo = m.BooleanField()
    #variant_normal = m.BooleanField()
    #variant_reverse = m.BooleanField()
    #variant_w_promo = m.BooleanField()
    
    
    

