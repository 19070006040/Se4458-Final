from django.contrib import admin

from .models import Hotels


# Register your models here.
@admin.register(Hotels)
class HotelsAdmin(admin.ModelAdmin):

    list_display = ["name", "title_description", "embed_link", "rating", "cover_photo", "price", "comment_quantity", "amenities"]

    class Meta:
        model = Hotels