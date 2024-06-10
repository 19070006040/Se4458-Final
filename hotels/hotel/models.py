from django.db import models


# Create your models here.
class Hotels(models.Model):
    name = models.CharField(verbose_name="name", max_length=200)
    title_description = models.TextField(verbose_name="One title about the hotel")
    embed_link = models.TextField(verbose_name="Link for iframe tag")
    map_link = models.TextField(verbose_name="Link for google maps", default="deneme")
    rating = models.IntegerField(verbose_name="Hotel Rating(Max. 10)", default=1)
    city = models.CharField(verbose_name="city", max_length=200, default="istanbul")
    cover_photo = models.FileField(verbose_name="Cover Photo", blank=True, null=True)
    price = models.IntegerField(verbose_name="Price", default=1)
    comment_quantity = models.IntegerField(verbose_name="Number of comments", default=1)
    amenities = models.CharField(verbose_name="Enter the amenities.(split with ,)", max_length=200)
    discounted_price = models.IntegerField(verbose_name="Discounted Price", default=1)