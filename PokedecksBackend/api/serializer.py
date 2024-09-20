from rest_framework import serializers
from .models.series import Series

class SeriesSerializer(serializers.ModelSerializer):
    class Meta:
        model = Series
        fields = '__all__'