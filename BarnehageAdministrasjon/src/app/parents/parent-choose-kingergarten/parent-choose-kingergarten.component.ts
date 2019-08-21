import { Component, OnInit } from '@angular/core';
import { tileLayer, LatLngExpression } from 'leaflet';
declare let L;
@Component({
  selector: 'app-parent-choose-kingergarten',
  templateUrl: './parent-choose-kingergarten.component.html',
  styleUrls: ['./parent-choose-kingergarten.component.scss']
})
export class ParentChooseKingergartenComponent implements OnInit {
  map: any;
  apiKey = 'dc14f606-8d5c-43ea-baba-3a45447a79d0';
  homePosition: any;
  lat = '59.685009';
  lng = '9.647300';
  constructor() { }

  ngOnInit() {
    this.addNorkartMap();
    this.addHomeMarker();
  }

  addNorkartMap() {
    this.homePosition = L.latLng(this.lat, this.lng);
    this.map = L.map('map').setView(this.homePosition, 18);
    const apiKey = this.apiKey;
    const baseLayers = {
      'Kart': L.tileLayer.webatlas({
        mapType: L.TileLayer.Webatlas.Type.VECTOR,
        apikey: apiKey
      }),
      'Kart, Gråtone': L.tileLayer.webatlas({
        mapType: L.TileLayer.Webatlas.Type.GREY,
        apikey: apiKey
      }),
      'Kart, medium': L.tileLayer.webatlas({
        mapType: L.TileLayer.Webatlas.Type.MEDIUM,
        apikey: apiKey
      }),
      'Kart, lite': L.tileLayer.webatlas({
        mapType: L.TileLayer.Webatlas.Type.LITE,
        apikey: apiKey
      }),
      'Foto': L.tileLayer.webatlas({
        mapType: L.TileLayer.Webatlas.Type.AERIAL,
        apikey: apiKey
      }),
      'Hybrid': L.tileLayer.webatlas({
        mapType: L.TileLayer.Webatlas.Type.HYBRID,
        apikey: apiKey
      }),
      'Custom-Kart': L.tileLayer.webatlas({
        mapType: L.TileLayer.Webatlas.Type.VECTOR,
        apikey: apiKey,
        tileset: {
          vector: { tileset: 'webatlas-1881-vektor', ext: 'png' }
        }
      }),
      'Custom-Hybrid': L.tileLayer.webatlas({
        mapType: L.TileLayer.Webatlas.Type.HYBRID,
        apikey: apiKey,
        tileset: {
          hybrid: { tileset: 'webatlas-1881-hybrid', ext: 'jpeg' }
        }
      }).addTo(this.map)
    };
    const overlayMaps = {
    };
    L.control.layers(baseLayers, overlayMaps).addTo(this.map);
  }

  addHomeMarker() {
    const homeIcon = new L.Icon({ iconSize: [25, 25], iconAnchor: [25, 25], iconUrl: '../assets/images/home-map-location.png' });
    const homeMarker = L.marker(this.homePosition, { icon: homeIcon, draggable: false });
    homeMarker.bindPopup('home');
    homeMarker.addTo(this.map);
  }

}
