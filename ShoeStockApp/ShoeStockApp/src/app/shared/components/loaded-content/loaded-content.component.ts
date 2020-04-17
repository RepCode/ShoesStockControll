import { Component, OnInit, ChangeDetectionStrategy, Input } from '@angular/core';

@Component({
  selector: 'app-loaded-content',
  templateUrl: './loaded-content.component.html',
  styleUrls: ['./loaded-content.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class LoadedContentComponent implements OnInit {

  @Input() isLoading: boolean;
  @Input() hasFailed: boolean;

  constructor() { }

  ngOnInit(): void {
  }

}
