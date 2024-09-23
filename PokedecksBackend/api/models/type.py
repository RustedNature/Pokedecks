from django.db import models

#Pokemon types like, fire grass etc
class Type(models.Model):
    name = models.CharField(max_length=255)

    def __str__(self):
        return self.name
    
    
    