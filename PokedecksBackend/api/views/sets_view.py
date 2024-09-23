from rest_framework.decorators import api_view
from rest_framework.response import Response
from rest_framework import status
from ..models.set import Set
from ..serializer import SetSerializer


@api_view(['GET'])
def get_sets(request):
    sets = Set.objects.all()
    serializer = SetSerializer(sets, many=True)
    return Response(serializer.data, status=status.HTTP_200_OK)

@api_view(['POST',"GET"])
def create_set(request):
    serializer = SetSerializer(data=request.data)

    if serializer.is_valid():
        serializer.save()
        return Response(serializer.data, status=status.HTTP_201_CREATED)
    return Response(serializer.errors, status=status.HTTP_400_BAD_REQUEST)

@api_view(['DELETE', 'GET'])
def delete_set(request, set_id):
    try:
        set = Set.objects.get(id=set_id)
    except Set.DoesNotExist:
        return Response({'detail': 'Not found.'}, status=status.HTTP_404_NOT_FOUND)

    set.delete()
    return Response(status=status.HTTP_204_NO_CONTENT)

@api_view(['PUT'])
def update_set(request, set_id):
    try:
        set = Set.objects.get(id=set_id)
    except Set.DoesNotExist:
        return Response({'detail': 'Not found.'}, status=status.HTTP_404_NOT_FOUND)

    serializer = SetSerializer(set, data=request.data)

    if serializer.is_valid():
        serializer.save()
        return Response(serializer.data, status=status.HTTP_200_OK)