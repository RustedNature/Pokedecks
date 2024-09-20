from django.db import models

# Create your models here.
class Series(models.Model):
    id = models.CharField(max_length=50, primary_key=True)
    name = models.CharField(max_length=255)
    logo = models.ImageField(null=True, blank=True)


    def __str__(self):
        return self.name
    

