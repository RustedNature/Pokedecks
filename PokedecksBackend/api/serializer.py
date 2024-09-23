from rest_framework import serializers
from .models.series import Series
from .models.set import Set
from .models.card import Card

class SeriesSerializer(serializers.ModelSerializer):
    class Meta:
        model = Series
        fields = '__all__'
        extra_kwargs = {
            'id': {'error_messages': {'required': 'Series id is required'}}
        }
    
class SetSerializer(serializers.ModelSerializer):
    class Meta:
        model = Set
        fields = '__all__'

class CardSerializer(serializers.ModelSerializer):
    class Meta:
        model = Card
        fields = '__all__'