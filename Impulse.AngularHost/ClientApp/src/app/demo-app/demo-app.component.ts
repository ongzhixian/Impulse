import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-demo-root',
  templateUrl: './demo-app.component.html',
  styleUrls: ['./demo-app.component.css']
})
export class DemoAppComponent implements OnInit {
  title = 'demo-app';

  constructor() { }

  ngOnInit() {
  }

}
