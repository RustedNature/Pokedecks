from django.db import models

class Attack(models.Model):
    name = models.CharField(max_length=255)
    text = models.TextField()
    cost = models.JSONField()
    damage = models.CharField(max_length=255)
    convertedEnergyCost = models.IntegerField()
    def __str__(self):
        return self.name