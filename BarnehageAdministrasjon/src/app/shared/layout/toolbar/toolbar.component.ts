import { Component, OnInit, Input, ElementRef, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.scss']
})
export class ToolbarComponent implements OnInit {
  @Input() isExpandedToolBar: boolean;
  @Output() messageToEmit = new EventEmitter<boolean>();
  constructor() { }

  ngOnInit() {
  }
  changeValue(message: boolean) {
    this.messageToEmit.emit(!message);
  }
}
