import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StoriesList } from './stories-list';

describe('StoriesList', () => {
  let component: StoriesList;
  let fixture: ComponentFixture<StoriesList>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [StoriesList]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StoriesList);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
