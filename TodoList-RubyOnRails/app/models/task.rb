class Task < ApplicationRecord
    validates :title, presence: true, length: { minimum: 3}
    validates :description, presence: true, length: { minimum: 5, maximum: 30 }
    validates :isActive,  inclusion: { in: [true, false] }
end
