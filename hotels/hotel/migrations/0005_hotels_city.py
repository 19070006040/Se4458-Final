# Generated by Django 5.0.1 on 2024-01-09 20:14

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('hotel', '0004_alter_hotels_embed_link'),
    ]

    operations = [
        migrations.AddField(
            model_name='hotels',
            name='city',
            field=models.CharField(default='istanbul', max_length=200, verbose_name='city'),
        ),
    ]