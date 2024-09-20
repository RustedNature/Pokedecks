from rest_framework.decorators import api_view
from rest_framework.response import Response
from rest_framework import status
from .models.series import Series
from .serializer import SeriesSerializer
from api import serializer

@api_view(['GET'])
def get_series(request):
    series = Series.objects.all()
    serializer = SeriesSerializer(series, many=True)
    return Response(serializer.data, status=status.HTTP_200_OK)


@api_view(['POST'])
def create_series(request):
    serializer = SeriesSerializer(data=request.data)

    if serializer.is_valid():
        serializer.save()
        return Response(serializer.data, status=status.HTTP_201_CREATED)
    return Response(serializer.errors, status=status.HTTP_400_BAD_REQUEST)


@api_view(['DELETE', 'GET'])
def delete_series(request, id):
    try:
        series = Series.objects.get(id=id)
    except Series.DoesNotExist:
        return Response({'detail': 'Not found.'}, status=status.HTTP_404_NOT_FOUND)

    series.delete()
    return Response(status=status.HTTP_204_NO_CONTENT)
