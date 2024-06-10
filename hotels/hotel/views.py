from django.shortcuts import HttpResponse, get_object_or_404, render

from .models import Hotels


# Create your views here.
def index(request):

    if request.method == "POST":
        sehir = request.POST.get("city")
        enter = request.POST.get("enter")
        exit = request.POST.get("exit")
        room = request.POST.get("room")

        enter_day = enter.split("-")[2]
        exit_day = exit.split("-")[2]

        stayed_days = int(exit_day) - int(enter_day)

        hotels = Hotels.objects.filter(city = sehir)

        total_price = int(stayed_days) * int(room)

        return render(request, "index.html", {"hotels": hotels, "days": stayed_days, "room": room, "price": total_price})
    
    else:
        hotels = Hotels.objects.all()

        return render(request, "index.html", {"hotels": hotels})
 
def detail(request, id):
    hotel = get_object_or_404(Hotels, id=id)

    hotel_amenities = hotel.amenities.split(",")

    return render(request, "detail.html", {"hotel": hotel, "amenities": hotel_amenities})